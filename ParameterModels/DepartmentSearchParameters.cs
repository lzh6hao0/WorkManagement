﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkManagement.ParameterModels
{
    public class DepartmentSearchParameters
    {
        public int CompanyId { get; set; }
        public string DepartmentName { get; set; }
        private const int MaxPageSize = 20;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
