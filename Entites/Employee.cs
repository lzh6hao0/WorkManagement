using System;
using System.ComponentModel.DataAnnotations.Schema;
using WorkManagement.Enums;

namespace WorkManagement.Entites
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }
        public string EmployeeNo { get; set; }
        public string Name { get; set; }
        public string TelNum { get; set; }
        public string Email { get; set; }
        public Title Title { get; set; }//职位
        public Gender Gender { get; set; }
        public DateTime HireDate { get; set; }//入职时间
        public WorkStatusType WorkStatus { get; set; }//状态

        public Department Department { get; set; }
    }
}