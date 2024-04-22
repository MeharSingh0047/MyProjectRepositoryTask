using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyProject.Employee.Employee;

namespace MyProject.Employee.dto
{
    public class EmployeeDto:EntityDto
    {
        public string Name { get; set; }
        public gender Gender { get; set; }
        public bool IsMarried { get; set; }
        public int DepId { get; set; }
     

    }
}
