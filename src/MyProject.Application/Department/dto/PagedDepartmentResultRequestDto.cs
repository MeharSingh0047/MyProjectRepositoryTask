﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Department.dto
{
    public class PagedDepartmentResultRequestDto:PagedResultRequestDto
    {

        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
