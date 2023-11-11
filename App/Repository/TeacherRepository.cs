using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Repository
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacher
    {
        private readonly ApiContext _context;
        public TeacherRepository(ApiContext context) : base(context)
        {
            _context = context;
        }
    }
}