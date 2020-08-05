using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Entites;
using WorkManagement.Models;

namespace WorkManagement.Profiles
{
    public class CompanyProfile:Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanySearchResDto>();//数据库字段和查询返回结果对应关系
            CreateMap<CompanyAddDto, Company>();
        }
    }
}
