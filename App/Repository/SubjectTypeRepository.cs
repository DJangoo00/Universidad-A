using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository
{
    public class SubjectTypeRepository : GenericRepository<SubjectType>, ISubjectType
    {
        private readonly ApiContext _context;
        public SubjectTypeRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
    }
}