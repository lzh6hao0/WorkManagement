using WorkManagement.Enums;

namespace WorkManagement.Models
{
    public class CompanySearchResDto
    {
        public string Name { get; set; }
        public string CompanyNo { get; set; }//公司编号
        public IsValidType ValidType { get; set; }
        public string Remark { get; set; }
    }
}
