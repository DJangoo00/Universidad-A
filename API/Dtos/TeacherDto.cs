using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TeacherDto : BaseEntity
    {
        public int IdPersonFk {get; set;}
        public PersonDto Person {get; set;}
        public int IdDepartamentFk {get; set;}
        public DepartamentDto Departament {get; set;}
    }
}