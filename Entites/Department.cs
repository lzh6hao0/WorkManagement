using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WorkManagement.Enums;

namespace WorkManagement.Entites
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string DepartmentNo { get; set; }
        public string Introduction { get; set; }
        public int? ParentDeptId { get; set; }
        public IsValidType ValidType{ get; set; }
        public int? CreaterId { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Remark { get; set; }

        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }


    }
}