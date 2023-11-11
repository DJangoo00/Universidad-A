using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Repository
{
    public class SchoolarCurseRepository : GenericRepository<SchoolarCurse>, ISchoolarCurse
    {
        private readonly ApiContext _context;
        public SchoolarCurseRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
    }
}