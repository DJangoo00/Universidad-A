using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SchoolarCurseDto : BaseEntity
    {
        public int Start {get; set;}
        public int Finish {get; set;}
    }
}