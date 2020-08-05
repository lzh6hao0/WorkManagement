using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WorkManagement.Entites;
using WorkManagement.Models;

namespace WorkManagement.Profiles
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentSearchResDto>();
            CreateMap<DepartmentAddDto, Department>();
        }
    }
}
