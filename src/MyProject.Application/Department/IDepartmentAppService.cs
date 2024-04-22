using Abp.Application.Services;
using MyProject.Department.dto;
using MyProject.Employee.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Department
{
    public interface IDepartmentAppService:IApplicationService
    {
        public List<DepartmentDto> getDepartments();
    }
}
