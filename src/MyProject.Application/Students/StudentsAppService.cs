using Abp.Application.Services;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using MyProject.Employee.dto;
using MyProject.Std;
using MyProject.Students.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Students
{
    public class StudentsAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, StudentDto, StudentDto>, IStudentsAppService
    {
        public StudentsAppService(IRepository<Student> repository):base(repository) 
        {
            
        }
        public List<StudentDto> getStudents()
        {
            var std = Repository.GetAll().ToList();
            return new List<StudentDto>(ObjectMapper.Map<List<StudentDto>>(std));
        }

        protected override IQueryable<Student> CreateFilteredQuery(PagedStudentResultRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        protected override async Task<Student> GetEntityByIdAsync(int id)
        {
            var emp = await Repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);

            if (emp == null)
            {
                throw new EntityNotFoundException(typeof(Student), id);
            }

            return emp;
        }

        protected override IQueryable<Student> ApplySorting(IQueryable<Student> query, PagedStudentResultRequestDto input)
        {
            return query.OrderBy(r => r.Name);
        }
    }
}
