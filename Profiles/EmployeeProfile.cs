using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Entites;
using WorkManagement.Models;

namespace WorkManagement.Profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeSearchResDto>()
                .ForMember(dest=>dest.GenderDisplay,opt=>opt.MapFrom(src=>src.Gender.ToString()))//性别
                .ForMember(dest => dest.TitleDisplay, opt => opt.MapFrom(src => src.Title.ToString()))//职位
                .ForMember(dest => dest.WorkStatusDisplay, opt => opt.MapFrom(src => src.WorkStatus.ToString()));//在职状态
        }
    }
}
