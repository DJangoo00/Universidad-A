using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Name {get; set;}
        public double/* float */ Credits {get; set;}
        public int IdSubjectTypeFk {get; set;}
        public SubjectType SubjectType {get; set;}
        public int Curse {get; set;}
        public int Period {get; set;}
        public int? IdTeacherFk {get; set;}
        public Teacher Teacher {get; set;}
        public int IdGradeFk {get; set;}
        public Grade Grade {get; set;}
        public ICollection<SubjectRegister> SubjectsRegisters {get; set;}
        
    }
}