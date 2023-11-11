using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubjectRegister
    {
        public int IdStudentFk {get; set;}
        public Person Student {get; set;}
        public int IdSubjectFk {get; set;}
        public Subject Subject {get; set;}
        public int IdSchoolarCurseFk {get; set;}
        public SchoolarCurse SchoolarCurse {get; set;}
    }
}