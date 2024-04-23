using Abp.Application.Services;
using MyProject.Students.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Students
{
    public interface IStudentsAppService:IApplicationService
    {
        List<StudentDto> getStudents();
    }
}
