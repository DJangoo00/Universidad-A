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
                orderby p.LastName1 , p.LastName2 , p.FirstName 
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
                orderby p.LastName1 , p.LastName2 , p.FirstName 
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
                where p.Birthday.Year ==1999
                orderby p.LastName1 , p.LastName2 , p.FirstName 
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
                orderby p.LastName1 , p.LastName2 , p.FirstName 
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
                orderby p.LastName1 , p.LastName2 , p.FirstName 
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
    
    }
}