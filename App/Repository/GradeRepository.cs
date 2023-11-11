using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.Repository
{
    public class GradeRepository : GenericRepository<Grade>, IGrade
    {
        private readonly ApiContext _context;
        public GradeRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
    }
}