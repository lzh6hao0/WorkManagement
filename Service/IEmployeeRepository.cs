using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Entites;
using WorkManagement.ParameterModels;

namespace WorkManagement.Service
{
    public interface IEmployeeRepository
    {
        //Task<IEnumerable<Employee>> GetEmployeesAsync(int companyId,int? departmentId);
        Task<Employee> GetEmployeeAsync(int employeeId);
        Task<Employee> GetEmployeeAsync(int departmentId, int employeeId);
        Task<IEnumerable<Employee>> GetEmployeesAsync(EmployeeSearchParameters parameters);
        void AddEmployee(Employee employee);
       // void AddEmployee(int? departmentId, Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Task<bool> IsEmployeeExistsAsync(int employeeId);

        Task<bool> SaveAsync();
    }
}
