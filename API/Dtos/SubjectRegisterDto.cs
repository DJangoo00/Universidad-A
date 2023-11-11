using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubjectRegisterDto
    {
        public int IdStudentFk {get; set;}
        public PersonDto Student {get; set;}
        public int IdSubjectFk {get; set;}
        public SubjectDto Subject {get; set;}
        public int IdSchoolarCurseFk {get; set;}
        public SchoolarCurseDto SchoolarCurse {get; set;}
    }
}