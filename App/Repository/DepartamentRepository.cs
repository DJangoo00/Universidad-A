using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Repository
{
    public class DepartamentRepository : GenericRepository<Departament>, IDepartament
    {
        private readonly ApiContext _context;
        public DepartamentRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Departament>> GetAllAsync()
        {
            return await _context.Departaments
                .ToListAsync();
        }

        public override async Task<Departament> GetByIdAsync(int id)
        {
            return await _context.Departaments
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}