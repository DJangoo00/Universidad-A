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

        //10. Devuelve un listado con el nombre de todos los departamentos que tienen profesores que imparten alguna asignatura en el `Grado en Ingeniería Informática (Plan 2015)`.
        public async Task<IEnumerable<object>> Get10()
        {
            var result = await
            (
                from d in _context.Departaments
                join t in _context.Teachers on d.Id equals t.IdDepartamentFk
                join s in _context.Subjects on t.Id equals s.IdTeacherFk
                join g in _context.Grades on s.IdGradeFk equals g.Id
                where g.Id == 4
                orderby d.Id
                select new
                {
                    Id = d.Id,
                    Nombre = d.Name,
                }
            )
            .Distinct()
            .OrderBy (s => s.Id)
            .ToListAsync();
            return result;
        }

    }
}