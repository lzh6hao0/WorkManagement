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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly WorkManagementDbContext context;

        public CompanyRepository(WorkManagementDbContext context) {
            this.context = context;
        }
        public async Task<IEnumerable<Company>> GetCompaniesAsync(CompanySearchParameters parameters)
        {
            var companies = context.Companies as IQueryable<Company>;
            if (!string.IsNullOrWhiteSpace(parameters?.CompanyName))
            {
                companies = companies.Where(c=>c.Name.Contains(parameters.CompanyName));
            }
            return await companies?.OrderBy(c=>c.Name).ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<int> companyIds)
        {
            return await context.Companies
                .Where(c => companyIds.Contains(c.Id))
                .OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<Company> GetCompanyAsync(int companyId)
        {
            return await context.Companies.FirstOrDefaultAsync(c => c.Id==companyId);
        }
        public void AddCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }
            company.CreateTime = DateTime.Now;
            context.Companies.Add(company);
        }

        public void UpdateCompany(Company company)
        {
            //throw new NotImplementedException();
        }

        public void DeleteCompany(Company company)
        {
            if (company == null)
            {
                throw new  ArgumentNullException(nameof(company));
            }
            context.Companies.Remove(company);
        }
        public async Task<bool> IsCompanyExistsAsync(int companyId)
        {
            return await context.Companies.AnyAsync(c => c.Id == companyId && c.ValidType==IsValidType.Valid);
        }

       

       

        public async Task<Department> GetDepartmentAsync(int companyId, int departmentId)
        {
            return await context.Departments
                .FirstOrDefaultAsync(x => x.CompanyId == companyId && x.Id == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync(DepartmentSearchParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var departments = context.Departments.Where(d => d.CompanyId == parameters.CompanyId);
            if(departments!=null && !string.IsNullOrWhiteSpace(parameters.DepartmentName))
            {
                departments = departments.Where(d => d.Name.Contains(parameters.DepartmentName));
            }
            return await departments.OrderBy(d => d.Name).ToListAsync();
        }      

        public void AddDepartment(int companyId, Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            department.CompanyId = companyId;
            context.Departments.Add(department);
        }

        public void UpdateDepartment(Department department)
        {
            //throw new NotImplementedException();
        }
        public void DeleteDepartment(Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }
            context.Departments.Remove(department);

        }
        public async Task<bool> IsDepartmentExistsAsync(int companyId,int departmentId)
        {
            return await context.Departments.AnyAsync(x => x.CompanyId == companyId && x.Id == departmentId);
        }

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

       

       
    }
}
