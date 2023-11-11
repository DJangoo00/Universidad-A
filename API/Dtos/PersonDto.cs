using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PersonDto : BaseEntity
    {
        public string DNI {get; set;}
        public string FirstName {get; set;}
        public string LastName1 {get; set;}
        public string LastName2 {get; set;}
        public string City {get; set;}
        public string Adress {get; set;}
        public string? Telephone {get; set;}
        public DateOnly Birthday {get; set;}
        public int IdGenderFk {get; set;}
        public GenderDto Gender {get; set;}
        public int IdPersonTypeFk {get; set;}
        public PersonTypeDto PersonType {get; set;}
        public TeacherDto Teacher {get; set;}
        

    }
}