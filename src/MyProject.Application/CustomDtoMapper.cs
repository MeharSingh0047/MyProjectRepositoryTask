using AutoMapper;
using MyProject.Department.dto;
using MyProject.Employee.dto;


namespace MyProject
{
    public class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<EmployeeDto, Employee.Employee>().ReverseMap();
            configuration.CreateMap<DepartmentDto, Department.Department>().ReverseMap();

        }
    }
}
