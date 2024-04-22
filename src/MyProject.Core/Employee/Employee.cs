using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Employee
{
    public class Employee:Entity
    {
        public string Name { get; set; }
        
        public gender Gender { get; set; }
        public bool IsMarried { get; set; }
        public int DepId {  get; set; }
        [ForeignKey(nameof(DepId))]
        public Department.Department department { get; set; }
    }

    public enum gender { Male = 1, Female = 2, Others = 3 }
}
