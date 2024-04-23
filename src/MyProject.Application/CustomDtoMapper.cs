using AutoMapper;
using MyProject.Department.dto;
using MyProject.Employee.dto;
using MyProject.Std;
using MyProject.Students.dto;


namespace MyProject
{
    public class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<EmployeeDto, Employee.Employee>().ReverseMap();
            configuration.CreateMap<DepartmentDto, Department.Department>().ReverseMap();
            configuration.CreateMap<StudentDto, Student>().ReverseMap();

        }
    }
}
