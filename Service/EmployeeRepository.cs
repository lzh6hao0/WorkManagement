using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Data;
using WorkManagement.Entites;
using WorkManagement.Enums;
using WorkManagement.ParameterModels;

namespace WorkManagement.Service
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly WorkManagementDbContext context;

        public EmployeeRepository(WorkManagementDbContext context)
        {
            this.context = context;
        }
        public void AddEmployee( Employee employee)
        {
           
            //if (departmentId == null)
            //{
            //    throw new ArgumentNullException(nameof(departmentId));
            //}
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            //employee.DepartmentId = (int)departmentId;
            context.Employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            context.Employees.Remove(employee);
        }

        public async Task<Employee> GetEmployeeAsync(int departmentId, int employeeId)
        {
            return await context.Employees.FirstOrDefaultAsync(x => x.DepartmentId == departmentId && x.Id == employeeId);
        }
        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            return await context.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync(EmployeeSearchParameters parameters)
        {         
            var employees = context.Employees as IQueryable<Employee>;                        
            if (!string.IsNullOrWhiteSpace(parameters.GenderDisplay))
            {
                var gender = Enum.Parse<Gender>(parameters.GenderDisplay.Trim());
                employees = employees.Where(e => e.Gender == gender);
            }
            if (!string.IsNullOrWhiteSpace(parameters.EmployeeNo))
            {
                employees = employees.Where(e => e.EmployeeNo.Contains(parameters.EmployeeNo));
            }
            if (!string.IsNullOrWhiteSpace(parameters.Name))
            {
                employees = employees.Where(e => e.Name.Contains(parameters.Name));
            }
            //TODO:添加其它查询条件
            return await employees
                .OrderBy(e => e.DepartmentId).OrderBy(e=>e.EmployeeNo)
                .ToListAsync();
        }

        public async Task<bool> IsEmployeeExistsAsync(int employeeId)
        {
            return await context.Employees.AnyAsync(x => x.Id == employeeId);
        }

       

        public void UpdateEmployee(Employee employee)
        {
            
        }

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync()>0;
        }
    }
}
