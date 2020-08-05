using System;
using WorkManagement.Enums;

namespace WorkManagement.Models
{
    public class DepartmentAddDto
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string DepartmentNo { get; set; }
        public string Introduction { get; set; }
        public int? ParentDeptId { get; set; }
        public IsValidType ValidType { get; set; } = IsValidType.Valid;
        public int? CreaterId { get; set; }

        private DateTime? _createTime = DateTime.Now;
        public DateTime? CreateTime {
            get => _createTime;
            set => _createTime= value ?? _createTime;
        }
        public string Remark { get; set; }

        
    }
}
