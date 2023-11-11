using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SchoolarCurse : BaseEntity
    {
        public int Start {get; set;}
        public int Finish {get; set;}
        public ICollection<SubjectRegister> SubjectsRegisters {get; set;}
    }
}