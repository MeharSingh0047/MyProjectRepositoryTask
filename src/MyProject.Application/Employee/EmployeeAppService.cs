using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyProject.Authorization.Roles;
using MyProject.Authorization.Users;
using MyProject.Employee.dto;
using MyProject.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Employee
{
    public class EmployeeAppService: AsyncCrudAppService<Employee, EmployeeDto, int, PagedEmployeeResultRequestDto, EmployeeDto, EmployeeDto>, IEmployeeAppService
    {

        public EmployeeAppService(IRepository<Employee> repository):base(repository)
        {
            
        }
        protected override IQueryable<Employee> CreateFilteredQuery(PagedEmployeeResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        protected override async Task<Employee> GetEntityByIdAsync(int id)
        {
            var emp = await Repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

            if (emp == null)
            {
                throw new EntityNotFoundException(typeof(Employee), id);
            }

            return emp;
        }

        protected override IQueryable<Employee> ApplySorting(IQueryable<Employee> query, PagedEmployeeResultRequestDto input)
        {
            return query.OrderBy(r => r.Name);
        }

        public List<EmployeeDto> getEmployee()
        {
            var emp = Repository.GetAll().ToList();
            return new List<EmployeeDto>(ObjectMapper.Map<List<EmployeeDto>>(emp));
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected override Employee MapToEntity(EmployeeDto createInput)
        {
            var emp = ObjectMapper.Map<Employee>(createInput);
            return emp;
        }

        protected override void MapToEntity(EmployeeDto input, Employee emp)
        {
            ObjectMapper.Map(input, emp);
        }

        protected override EmployeeDto MapToEntityDto(Employee emp)
        {
            var userDto = base.MapToEntityDto(emp);

            return userDto;
        }
    }
}
