using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPerson
    {
        private readonly ApiContext _context;
        public PersonRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        //1. Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre.
        public async Task<IEnumerable<object>> Get1()
        {
            var result = await
            (
                from p in _context.Persons
                join pt in _context.PersonsTypes on p.IdPersonTypeFk equals pt.Id
                where pt.Id == 1
                orderby p.LastName1, p.LastName2, p.FirstName
                select new
                {
                    ApellidoUno = p.LastName1,
                    ApellidoDos = p.LastName2,
                    Nombre = p.FirstName
                }

            )
            .ToListAsync();
            return result;
        }

        //2. Averigua el nombre y los dos apellidos de los alumnos que **no** han dado de alta su número de teléfono en la base de datos.
        public async Task<IEnumerable<object>> Get2()
        {
            var result = await
            (
                from p in _context.Persons
                join pt in _context.PersonsTypes on p.IdPersonTypeFk equals pt.Id
                where pt.Id == 1
                where p.Telephone == null
                orderby p.LastName1, p.LastName2, p.FirstName
                select new
                {
                    ApellidoUno = p.LastName1,
                    ApellidoDos = p.LastName2,
                    Nombre = p.FirstName,
                    DNI = p.DNI
                }
            )
            .ToListAsync();
            return result;
        }

        //3. Devuelve el listado de los alumnos que nacieron en `1999`.
        public async Task<IEnumerable<object>> Get3()
        {
            var result = await
            (
                from p in _context.Persons
                join pt in _context.PersonsTypes on p.IdPersonTypeFk equals pt.Id
                where pt.Id == 1
                where p.Birthday.Year == 1999
                orderby p.LastName1, p.LastName2, p.FirstName
                select new
                {
                    ApellidoUno = p.LastName1,
                    ApellidoDos = p.LastName2,
                    Nombre = p.FirstName,
                    DNI = p.DNI
                }
            )
            .ToListAsync();
            return result;
        }

        //4. Devuelve el listado de `profesores` que **no** han dado de alta su número de teléfono en la base de datos y además su nif termina en `K`.
        public async Task<IEnumerable<object>> Get4()
        {
            var result = await
            (
                from p in _context.Persons
                join pt in _context.PersonsTypes on p.IdPersonTypeFk equals pt.Id
                where pt.Id == 2
                where p.Telephone == null
                where p.DNI.ToLower().EndsWith("k")
                orderby p.LastName1, p.LastName2, p.FirstName
                select new
                {
                    ApellidoUno = p.LastName1,
                    ApellidoDos = p.LastName2,
                    Nombre = p.FirstName,
                    DNI = p.DNI
                }
            )
            .ToListAsync();
            return result;
        }

        //6. Devuelve un listado con los datos de todas las **alumnas** que se han matriculado alguna vez en el `Grado en Ingeniería Informática (Plan 2015)`
        public async Task<IEnumerable<object>> Get6()
        {
            var result = await
            (
                from p in _context.Persons
                where p.IdPersonTypeFk == 1
                where p.IdGenderFk == 2
                join sr in _context.SubjectsRegisters on p.Id equals sr.IdStudentFk
                join s in _context.Subjects on sr.IdSubjectFk equals s.Id
                join g in _context.Grades on s.IdGradeFk equals g.Id
                where g.Id == 4
                orderby p.LastName1, p.LastName2, p.FirstName
                select new
                {
                    ApellidoUno = p.LastName1,
                    ApellidoDos = p.LastName2,
                    Nombre = p.FirstName,
                    DNI = p.DNI
                }
            )
            .Distinct()
            .ToListAsync();
            return result;
        }

        //8. Devuelve un listado de los `profesores` junto con el nombre del `departamento` al que están vinculados. El listado debe devolver cuatro columnas, `primer apellido, segundo apellido, nombre y nombre del departamento.` El resultado estará ordenado alfabéticamente de menor a mayor por los `apellidos y el nombre.`
        public async Task<IEnumerable<object>> Get8()
        {
            var result = await
            (
                from p in _context.Persons
                where p.IdPersonTypeFk == 2
                join t in _context.Teachers on p.Id equals t.IdPersonFk
                join d in _context.Departaments on t.IdDepartamentFk equals d.Id
                orderby p.LastName1, p.LastName2, p.FirstName
                select new
                {
                    ApellidoUno = p.LastName1,
                    ApellidoDos = p.LastName2,
                    Nombre = p.FirstName,
                    DNI = p.DNI,
                    IdDepartamento = p.Id,
                    Departamento = d.Name
                }
            )
            .Distinct()
            .ToListAsync();
            return result;
        }
        //11. Devuelve un listado con todos los alumnos que se han matriculado en alguna asignatura durante el curso escolar 2018/2019.
        public async Task<IEnumerable<object>> Get11()
        {
            var result = await
            (
                from p in _context.Persons
                where p.IdPersonTypeFk == 1
                join sr in _context.SubjectsRegisters on p.Id equals sr.IdStudentFk
                join sc in _context.SchoolarsCurses on sr.IdSchoolarCurseFk equals sc.Id
                where sc.Id == 5
                orderby p.LastName1, p.LastName2, p.FirstName
                select new
                {
                    ApellidoUno = p.LastName1,
                    ApellidoDos = p.LastName2,
                    Nombre = p.FirstName,
                    DNI = p.DNI,
                }
            )
            .Distinct()
            .ToListAsync();
            return result;
        }
        //12. Devuelve un listado con los nombres de **todos** los profesores y los departamentos que tienen vinculados. El listado también debe mostrar aquellos profesores que no tienen ningún departamento asociado. El listado debe devolver cuatro columnas, nombre del departamento, primer apellido, segundo apellido y nombre del profesor. El resultado estará ordenado alfabéticamente de menor a mayor por el nombre del departamento, apellidos y el nombre.
        public async Task<IEnumerable<object>> Get12()
        {
            var result = await
            (
                from t in _context.Teachers
                join p in _context.Persons on t.IdPersonFk equals p.Id into tpGroup
                from tp in tpGroup.DefaultIfEmpty()
                join d in _context.Departaments on t.IdDepartamentFk equals d.Id into tdGroup
                from td in tdGroup.DefaultIfEmpty()
                orderby td.Name, tp.LastName1, tp.LastName2, tp.FirstName
                select new
                {
                    NombreDepartamento = td != null ? td.Name : null,
                    ApellidoUno = tp.LastName1,
                    ApellidoDos = tp.LastName2,
                    NombreProfesor = tp.FirstName
                }
            )
            .ToListAsync();
            return result;
        }
        //13. Devuelve un listado con los profesores que no están asociados a un departamento.
        public async Task<IEnumerable<object>> Get13()
        {
            var result = await (
            from p in _context.Persons
            where p.IdPersonTypeFk == 2
            where !_context.Teachers.Any(p => p.IdPersonFk == p.Id)
            select new
            {
                Id = p.Id,
                Nombre = p.FirstName,
                ApellidoUno = p.LastName1,
                ApellidoDos = p.LastName2,
            })
            .ToListAsync();

            return result;
        }

        //14. Devuelve un listado con los profesores que no imparten ninguna asignatura.
        public async Task<IEnumerable<object>> Get14()
        {
            var result = await (
            from p in _context.Persons
            where p.IdPersonTypeFk == 2
            where !_context.Teachers.Any(p => p.IdPersonFk == p.Id)
            select new
            {
                Id = p.Id,
                Nombre = p.FirstName,
                ApellidoUno = p.LastName1,
                ApellidoDos = p.LastName2,
            })
            .ToListAsync();
            return result;
        }

        //17. Devuelve el número total de **alumnas** que hay.
        public async Task<IEnumerable<object>> Get17()
        {
            var result = await (
            from p in _context.Persons
            where p.IdPersonTypeFk == 1 && p.IdGenderFk == 2
            group p by p.IdGenderFk into sw
            select new
            {
                Alumnas = sw.Count()
            }
            )
            .ToListAsync();
            return result;
        }

        //18. Calcula cuántos alumnos nacieron en `1999`.
        public async Task<IEnumerable<object>> Get18()
        {
            var result = await (
            from p in _context.Persons
            where p.IdPersonTypeFk == 1 && p.Birthday.Year == 1999
            group p by p.Birthday.Year into s
            select new
            {
                Alumnos = s.Count()
            }
            )
            .ToListAsync();
            return result;
        }

        //19. Calcula cuántos profesores hay en cada departamento. El resultado sólo debe mostrar dos columnas, una con el nombre del departamento y otra con el número de profesores que hay en ese departamento. El resultado sólo debe incluir los departamentos que tienen profesores asociados y deberá estar ordenado de mayor a menor por el número de profesores.

        public async Task<IEnumerable<object>> Get19()
        {
            var result = await (
            from p in _context.Persons
            where p.IdPersonTypeFk == 2
            join t in _context.Teachers on p.Id equals t.IdPersonFk
            join d in _context.Departaments on t.IdDepartamentFk equals d.Id
            group new { p, t, d } by d.Name into dp
            select new
            {
                Departamento = dp.Key,
                Profesores = dp.Count()
            }
            )
            .OrderBy(dp => dp.Profesores)
            .ToListAsync();
            return result;
        }

        //24. Devuelve un listado que muestre cuántos alumnos se han matriculado de alguna asignatura en cada uno de los cursos escolares. El resultado deberá mostrar dos columnas, una columna con el año de inicio del curso escolar y otra con el número de alumnos matriculados.
        public async Task<IEnumerable<object>> Get24()
        {
            var result = await (
                from sr in _context.SubjectsRegisters
                join sc in _context.SchoolarsCurses on sr.IdSchoolarCurseFk equals sc.Id
                group new { sr, sc } by sc.Start into srcGroup
                orderby srcGroup.Count() descending
                select new
                {
                    Inicio = srcGroup.Key,
                    Estudiantes = srcGroup.Count()
                }
            )
            .ToListAsync();
            return result;
        }


        //26. Devuelve todos los datos del alumno más joven.
        public async Task<object> Get26()
        {
            var result = await (
            from p in _context.Persons
            where p.IdPersonTypeFk == 1
            orderby p.Birthday descending
            select new
            {
                Id = p.Id,
                Nombre = p.FirstName,
                ApellidoUno = p.LastName1,
                ApellidoDos = p.LastName2,
                FeachaNacimiento = p.Birthday
            }
            )
            .FirstOrDefaultAsync();
            return result;
        }

        //27. Devuelve un listado con los profesores que no están asociados  a un departamento.
        public async Task<IEnumerable<object>> Get27()
        {
            var result = await (
            from p in _context.Persons
            where p.IdPersonTypeFk == 2
            where !_context.Teachers.Any(t => t.IdPersonFk == p.Id)
            orderby p.Id
            select new
            {
                Id = p.Id,
                DNI = p.DNI,
                Nombre = p.FirstName,
                ApellidoUno = p.LastName1,
                ApellidoDos = p.LastName2,
            }
            )
            .ToListAsync();
            return result;
        }

        //29. Devuelve un listado con los profesores que tienen un departamento asociado y que no imparten ninguna asignatura.
        public async Task<IEnumerable<object>> Get29()
        {
            var result = await (
            from p in _context.Persons
            where p.IdPersonTypeFk == 2
            join t in _context.Teachers on p.Id equals t.IdPersonFk
            where !_context.Subjects.Any(s => s.IdTeacherFk == t.Id)
            orderby p.Id
            select new
            {
                Id = p.Id,
                DNI = p.DNI,
                Nombre = p.FirstName,
                ApellidoUno = p.LastName1,
                ApellidoDos = p.LastName2,
            }
            )
            .ToListAsync();
            return result;
        }
    }
}
