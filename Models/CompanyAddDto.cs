using System;
using WorkManagement.Enums;

namespace WorkManagement.Models
{
    public class CompanyAddDto
    {
        public string Name { get; set; }
        public string CompanyNo { get; set; }//公司编号
        public string Introduction { get; set; }
        public int? ParentCompanyId { get; set; }
        public IsValidType? ValidType { get; set; } =IsValidType.Valid;//添加的时候默认是生效状态
        public int? CreaterId { get; set; }
        public DateTime? CreateTime { get; set; } = DateTime.Now;
    }
}
