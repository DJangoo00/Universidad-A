using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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