using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubjectDto : BaseEntity
    {
        public string Name {get; set;}
        public double/* float */ Credits {get; set;}
        public int IdSubjectTypeFk {get; set;}
        public SubjectTypeDto SubjectType {get; set;}
        public int Curse {get; set;}
        public int Period {get; set;}
        public int IdTeacherFk {get; set;}
        public TeacherDto Teacher {get; set;}
        public int IdGradeFk {get; set;}
        public GradeDto Grade {get; set;}
        
    }
}