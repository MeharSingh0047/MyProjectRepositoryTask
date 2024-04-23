using Abp.Domain.Entities;
using MyProject.Department;
using MyProject.Employee;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Std
{
    public class Student:Entity
    {
        public string Name { get; set; }
        public gender stdGender { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public int DepId { get; set; }
        [ForeignKey(nameof(DepId))]
        public Department.Department department { get; set; }
    }
}
