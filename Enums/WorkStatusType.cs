using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkManagement.Enums
{
    public enum WorkStatusType
    {
        Regular = 1,//正式员工               
        Attachment = 2,//实习生
        ProbationPeriod = 3,//适用期
        Reemployment = 4,//返聘
        Temp = 5,//临时
        Transfer = 6,//调离
        Furlough = 7,//停薪留职
        QuitJob = 8,//离职
    }
}
