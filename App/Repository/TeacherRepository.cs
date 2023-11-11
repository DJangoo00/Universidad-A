using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
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