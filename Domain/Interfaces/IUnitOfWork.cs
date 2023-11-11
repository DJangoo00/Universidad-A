using Domain.Entities;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    //Entities Interfaces
    IDepartament Departaments { get; }
    IGender Genders { get; }
    IGrade Grades { get; }
    IPerson Persons { get; }
    IPersonType PersonTypes { get; }
    ISchoolarCurse SchoolarCurses { get; }
    ISubject Subjects { get; }
    ISubjectType SubjectTypes { get; }
    ITeacher Teachers { get; }
    //JWT
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }

    Task<int> SaveAsync();
}
