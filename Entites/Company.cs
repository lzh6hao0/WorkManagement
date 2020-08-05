using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WorkManagement.Enums;

namespace WorkManagement.Entites
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyNo { get; set; }//公司编号
        public string Introduction { get; set; }
        public int? ParentCompanyId { get; set; }
        public IsValidType ValidType { get; set; }
        public int? CreaterId { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Remark { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
