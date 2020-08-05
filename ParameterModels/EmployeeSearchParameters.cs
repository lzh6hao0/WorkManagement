using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Entites;

namespace WorkManagement.ParameterModels
{
    public class EmployeeSearchParameters
    {
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeeNo { get; set; }
        public string Name { get; set; }
        public string TelNum { get; set; }
        public string Email { get; set; }
        public string TitleDisplay { get; set; }//职位
        public string GenderDisplay { get; set; }
    }
}
