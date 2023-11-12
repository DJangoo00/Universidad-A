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
        Task<IEnumerable<object>> Get8();
        Task<IEnumerable<object>> Get11();
        Task<IEnumerable<object>> Get12();
        Task<IEnumerable<object>> Get13();
        Task<IEnumerable<object>> Get14();
        Task<IEnumerable<object>> Get17();
        Task<IEnumerable<object>> Get18();
        Task<IEnumerable<object>> Get19();
        Task<IEnumerable<object>> Get24();
        Task<object> Get26();
        Task<IEnumerable<object>> Get27();
        Task<IEnumerable<object>> Get29();
    }
}