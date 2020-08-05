using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WorkManagement.Data;
using WorkManagement.Entites;
using WorkManagement.Models;
using WorkManagement.ParameterModels;
using WorkManagement.Service;

namespace WorkManagement.Controllers
{
    [ApiController]
    [Route("api/Companies")]
    public class CompaniesController:ControllerBase
    {
        private readonly ICompanyRepository companyRepository;
        private readonly IMapper mapper;

        public CompaniesController(ICompanyRepository companyRepository,IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanySearchResDto>>> GetCompanies([FromQuery]CompanySearchParameters parameters)
        {
            var companies = await companyRepository.GetCompaniesAsync(parameters);
            if (companies == null)
            {
                return NotFound();
            }
            var companySearchDtos = mapper.Map<IEnumerable<CompanySearchResDto>>(companies);
            return Ok(companySearchDtos);
        }

        /// <summary>
        /// 查询具体某个Company信息
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("{companyId}", Name=nameof(GetCompany))]
        public async Task<ActionResult<CompanySearchResDto>> GetCompany(int companyId)
        {
            var company = await companyRepository.GetCompanyAsync(companyId);
            if (company == null)
            {
                return NotFound();
            } 
            var companySearchDto = mapper.Map<CompanySearchResDto>(company);
            return Ok(companySearchDto);
        }

        [HttpPost]
        public async Task<ActionResult<CompanySearchResDto>> AddCompany(CompanyAddDto company)
        {
            var entity = mapper.Map<Company>(company);
            companyRepository.AddCompany(entity);
            await companyRepository.SaveAsync();

            var companySearchDto = mapper.Map<CompanySearchResDto>(entity);
            return CreatedAtRoute(nameof(GetCompany), new { companyId = entity.Id }, companySearchDto);
        }

        [HttpDelete("{companyId}")]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            var company = await companyRepository.GetCompanyAsync(companyId);
            if (company == null)
            {
                return NotFound();
            }

            companyRepository.DeleteCompany(company);
            await companyRepository.SaveAsync();
            return NoContent();
        }
    }
}
