using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Enums;

namespace WorkManagement.Models
{
    public class EmployeeAddDto
    {
        [Display(Name = "公司编号")]
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        public int CompanyId { get; set; }
        [Display(Name = "部门编号")]
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        public int DepartmentId { get; set; }
        [Display(Name = "工号")]
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        public string EmployeeNo { get; set; }
        [Display(Name = "部门编号")]
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        [StringLength(15, MinimumLength = 5, ErrorMessage ="{0}的长度范围是{2}到{1}")]
        public string Name { get; set; }
        public string TelNum { get; set; }
        
        public string Email { get; set; }
        [Display(Name = "职位")]
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        public Title Title { get; set; }//职位
        [Display(Name = "性别")]
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        public Gender Gender { get; set; }
        [Display(Name = "入职时间")]
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        public DateTime HireDate { get; set; }//入职时间
        [Display(Name = "员工")]
        [Required(ErrorMessage = "{0}这个字段是必填的")]
        public WorkStatusType WorkStatus { get; set; }//状态
    }
}
