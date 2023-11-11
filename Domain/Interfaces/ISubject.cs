using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISubject : IGenericRepository<Subject>
    {
        Task<IEnumerable<Subject>> Get5();
        Task<IEnumerable<Subject>> Get7();
        Task<IEnumerable<object>> Get9();
    }
}