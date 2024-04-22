using Abp.Application.Services;
using MyProject.Employee.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Employee
{
    public interface IEmployeeAppService:IApplicationService
    {
        public List<EmployeeDto> getEmployee();
    }
}
