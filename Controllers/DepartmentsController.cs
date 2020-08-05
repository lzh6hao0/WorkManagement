using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Entites;
using WorkManagement.Models;
using WorkManagement.ParameterModels;
using WorkManagement.Service;

namespace WorkManagement.Controllers
{
    [ApiController]
    [Route("api/companies/{companyId}/departments")]
    public class DepartmentsController:ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public DepartmentsController(ICompanyRepository companyRepository,IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentSearchResDto>>> GetDepartmentsAsync(DepartmentSearchParameters parameters)
        {
            var departments = await companyRepository.GetDepartmentsAsync(parameters);
            if (departments == null)
            {
                return NotFound();
            }
            var deptSerchResDto = mapper.Map<IEnumerable<DepartmentSearchResDto>>(departments);
            return Ok(deptSerchResDto);
        }

        [HttpGet("{departmentId}",Name=nameof(GetDepartmentAsync))]
        public async Task<ActionResult<DepartmentSearchResDto>> GetDepartmentAsync(int companyId,int departmentId)
        {
            if (!await companyRepository.IsCompanyExistsAsync(companyId))
            {
                return NotFound();
            }
            var department = companyRepository.GetDepartmentAsync(companyId, departmentId);
            if (department == null)
            {
                return NotFound();
            }
            var departmentResDto = mapper.Map<DepartmentSearchResDto>(department);
            return Ok(departmentResDto);
        }
        
        [HttpPost]
        public async Task<ActionResult<DepartmentSearchResDto>> AddDepartmentAsync(int companyId,DepartmentAddDto department)
        {
            if (!await companyRepository.IsCompanyExistsAsync(companyId))
            {
                return NotFound();
            }
            var entity = mapper.Map<Department>(department);
            companyRepository.AddDepartment(companyId,entity);
            await companyRepository.SaveAsync();

            var departmentResDto = mapper.Map<DepartmentSearchResDto>(entity);
            return CreatedAtRoute(nameof(GetDepartmentAsync), 
                new { companyId, departmentId = entity.Id }, departmentResDto);
        }

        [HttpDelete("{departmentId}")]
        public async Task<IActionResult> DeleteDepartment(int companyId,int departmentId)
        {
            if (!await companyRepository.IsCompanyExistsAsync(companyId))
            {
                return NotFound();
            }
            var department = await companyRepository.GetDepartmentAsync(companyId, departmentId);
            if (department == null)
            {
                return NotFound();
            }
            companyRepository.DeleteDepartment(department);
            await companyRepository.SaveAsync();
            return NoContent();
        }
    }
}
