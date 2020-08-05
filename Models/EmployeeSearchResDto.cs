using System;

namespace WorkManagement.Models
{
    public class EmployeeSearchResDto
    {
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeeNo { get; set; }
        public string Name { get; set; }
        public string TelNum { get; set; }
        public string Email { get; set; }
        public string TitleDisplay { get; set; }//职位
        public string GenderDisplay { get; set; }
        public DateTime HireDate { get; set; }//入职时间
        public string WorkStatusDisplay { get; set; }//状态
    }
}
