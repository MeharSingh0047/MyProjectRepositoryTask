﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Students.dto
{
    public class PagedStudentResultRequestDto:PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}