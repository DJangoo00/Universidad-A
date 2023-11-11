using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GenderDto : BaseEntity
    {
        public string Name {get; set;}
        public ICollection<Person> Persons {get; set;}
    }
}