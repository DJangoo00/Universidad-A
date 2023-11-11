using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPerson : IGenericRepository<Person>
    {
        Task<IEnumerable<object>> Get1();
        Task<IEnumerable<object>> Get2();
        Task<IEnumerable<object>> Get3();
        Task<IEnumerable<object>> Get4();
        Task<IEnumerable<object>> Get6();
    }
}