using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MyProject.Department.dto;
using MyProject.Employee.dto;
using MyProject.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Department
{
    public class DepartmentAppService : AsyncCrudAppService<Department, DepartmentDto, int, PagedDepartmentResultRequestDto, DepartmentDto, DepartmentDto>, IDepartmentAppService
    {
        public DepartmentAppService(IRepository<Department> repository):base(repository)
        {
            
        }

        public List<DepartmentDto> getDepartments()
        {
            var dep = Repository.GetAll().ToList();
            return new List<DepartmentDto>(ObjectMapper.Map<List<DepartmentDto>>(dep));
        }

        protected IQueryable<Department> CreateFilteredQuery(PagedDepartmentResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        protected async Task<Department> GetEntityByIdAsync(int id)
        {
            var dep = await Repository.GetAllIncluding(x => x.Name).FirstOrDefaultAsync(x => x.Id == id);

            if (dep == null)
            {
                throw new EntityNotFoundException(typeof(Department), id);
            }

            return dep;
        }

        protected IQueryable<Department> ApplySorting(IQueryable<Department> query, PagedDepartmentResultRequestDto input)
        {
            return query.OrderBy(r => r.Name);
        }

    }
}
