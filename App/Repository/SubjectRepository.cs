using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Repository
{
    public class SubjectRepository : GenericRepository<Subject>, ISubject
    {
        private readonly ApiContext _context;
        public SubjectRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        //5. Devuelve el listado de las asignaturas que se imparten en el primer cuatrimestre, en el tercer curso del grado que tiene el identificador `7`.
        public async Task<IEnumerable<Subject>> Get5()
        {
            var result = await
            (
                from s in _context.Subjects
                where (s.Period == 1 && s.Curse == 3 && s.IdGradeFk == 7)
                orderby s.Id
                select s
            )
            .OrderBy (s => s.Id)
            .Include(st => st.SubjectType)
            .Include(st => st.Teacher)
            .Include(st => st.Grade)
            .ToListAsync();
            return result;
        }
    }
}