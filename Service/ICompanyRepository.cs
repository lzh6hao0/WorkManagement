using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Entites;
using WorkManagement.ParameterModels;

namespace WorkManagement.Service
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompaniesAsync(CompanySearchParameters parameters);
        Task<Company> GetCompanyAsync(int companyId);
        Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<int> companyIds);
        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
        Task<bool> IsCompanyExistsAsync(int companyId);

        Task<IEnumerable<Department>> GetDepartmentsAsync(DepartmentSearchParameters parameters);
        Task<Department> GetDepartmentAsync(int companyId,int departmentId);
        void AddDepartment(int companyId,Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(Department department);
        Task<bool> IsDepartmentExistsAsync(int companyId,int departmentId);

        Task<bool> SaveAsync();
    }
}
