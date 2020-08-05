using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Data;
using WorkManagement.Entites;
using WorkManagement.Models;
using WorkManagement.ParameterModels;
using WorkManagement.Service;

namespace WorkManagement.Controllers
{
    [ApiController]
    [Route("api/employees")]
    
    public class EmployeeController: ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRepository employeeRepository,IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeSearchResDto>>> GetEmployeesAsync(EmployeeSearchParameters parameters)
        {
            var employees = await employeeRepository.GetEmployeesAsync(parameters);
            if (employees == null)
            {
                return NotFound();
            }
            var employeeResDtos = mapper.Map<IEnumerable<EmployeeSearchResDto>>(employees);
            return Ok(employeeResDtos);
        }

        [HttpGet("{employeeId}",Name = nameof(GetEmployeeAsync))]
        public async Task<ActionResult<EmployeeSearchResDto>> GetEmployeeAsync(int employeeId)
        {
            var employee = await employeeRepository.GetEmployeeAsync(employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeResDto = mapper.Map<EmployeeSearchResDto>(employee);
            return Ok(employeeResDto);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeSearchResDto>> AddEmployeeAsync(EmployeeAddDto employee)
        {
            var entity = mapper.Map<Employee>(employee);
            employeeRepository.AddEmployee(entity);
            await employeeRepository.SaveAsync();

            var employeeResDto = mapper.Map<EmployeeSearchResDto>(employee);
            return CreatedAtRoute(nameof(GetEmployeeAsync), new { employeeId = entity.Id }, employeeResDto);
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            var employee = await employeeRepository.GetEmployeeAsync(employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            employeeRepository.DeleteEmployee(employee);
            await employeeRepository.SaveAsync();
            return NoContent();
        }

    }
}
