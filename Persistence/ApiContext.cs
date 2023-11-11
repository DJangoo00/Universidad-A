//dependencias externas
using Microsoft.EntityFrameworkCore;
using System.Reflection;
//namespaces internos
using Domain.Entities;

namespace Persistence;
public class ApiContext : DbContext //Clase de abstraccion para facilitar interaccion
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
    
    //DbSet para la funcionalidad
    public DbSet<Departament> Departaments { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<PersonType> PersonsTypes { get; set; }
    public DbSet<SchoolarCurse> SchoolarsCurses { get; set; }
    public DbSet<Subject> Subjects  { get; set; }
    public DbSet<SubjectRegister> SubjectsRegisters { get; set; }
    public DbSet<SubjectType> SubjectsTypes { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    //db para jwt
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleUser> RolesUsers { get; set; }
    //metodo para aplicar las configuracion de las entidades
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
