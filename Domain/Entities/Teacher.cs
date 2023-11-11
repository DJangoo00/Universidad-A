using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Teacher : BaseEntity
    {
        public int IdPersonFk {get; set;}
        public Person Person {get; set;}
        public int IdDepartamentFk {get; set;}
        public Departament Departament {get; set;}
        public ICollection<Subject> Subjects {get; set;}
    }
}