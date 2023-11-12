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

        //7. Devuelve un listado con todas las asignaturas ofertadas en el `Grado en Ingeniería Informática (Plan 2015)`.
        public async Task<IEnumerable<Subject>> Get7()
        {
            var result = await
            (
                from s in _context.Subjects
                where s.IdGradeFk == 4
                orderby s.Id
                select s
            )
            .OrderBy (s => s.Id)
            .Include(st => st.SubjectType)
            .Include(st => st.Teacher)
            .ToListAsync();
            return result;
        }

        //9. Devuelve un listado con el nombre de las asignaturas, año de inicio y año de fin del curso escolar del alumno con nif `26902806M`.
        public async Task<IEnumerable<object>> Get9()
        {
            var result = await
            (
                from s in _context.Subjects
                join sr in _context.SubjectsRegisters on s.Id equals sr.IdSubjectFk
                join p in _context.Persons on sr.IdStudentFk equals p.Id
                where p.IdPersonTypeFk == 1
                where p.DNI == "26902806M"
                join sc in _context.SchoolarsCurses on sr.IdSchoolarCurseFk equals sc.Id
                orderby s.Id
                select new
                {
                    Id = s.Id,
                    Nombre = s.Name,
                    Inicio = sc.Start,
                    Fin = sc.Finish,
                }
            )
            .OrderBy (s => s.Id)
            .ToListAsync();
            return result;
        }

        //15. Devuelve un listado con las asignaturas que no tienen un profesor asignado.   

        //25. Devuelve un listado con el número de asignaturas que imparte cada profesor. El listado debe tener en cuenta aquellos profesores que no imparten ninguna asignatura. El resultado mostrará cinco columnas: id, nombre, primer apellido, segundo apellido y número de asignaturas. El resultado estará ordenado de mayor a menor por el número de asignaturas.

        //30. Devuelve un listado con las asignaturas que no tienen un profesor asignado.
    }
}