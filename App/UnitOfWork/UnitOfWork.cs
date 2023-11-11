using App.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace App.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    //variables
    //repos
    private DepartamentRepository _departaments;
    private GenderRepository _genders;
    private GradeRepository _grades;
    private PersonRepository _persons;
    private PersonTypeRepository _personsTypes;
    private SchoolarCurseRepository _schoolarCurses;
    private SubjectRepository _subjects;
    private SubjectTypeRepository _subejctTypes;
    private TeacherRepository _teachers;

    //JWT
    private readonly ApiContext _context;
    private RoleRepository _roles;
    private UserRepository _users;
    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }
    //calls
    //main entities

    public IDepartament Departaments
    {
        get
        {
            if (_departaments == null)
            {
                _departaments = new DepartamentRepository(_context);
            }
            return _departaments;
        }
    }
    public IGender Genders
    {
        get
        {
            if (_genders == null)
            {
                _genders = new GenderRepository(_context);
            }
            return _genders;
        }
    }
    public IGrade Grades
    {
        get
        {
            if (_grades == null)
            {
                _grades = new GradeRepository(_context);
            }
            return _grades;
        }
    }
    public IPerson Persons
    {
        get
        {
            if (_persons == null)
            {
                _persons = new PersonRepository(_context);
            }
            return _persons;
        }
    }
    public IPersonType PersonTypes
    {
        get
        {
            if (_personsTypes == null)
            {
                _personsTypes = new PersonTypeRepository(_context);
            }
            return _personsTypes;

        }
    }
    public ISchoolarCurse SchoolarCurses
    {
        get
        {
            if (_schoolarCurses == null)
            {
                _schoolarCurses = new SchoolarCurseRepository(_context);
            }
            return _schoolarCurses;
        }
    }
    public ISubject Subjects
    {
        get
        {
            if (_subjects == null)
            {
                _subjects = new SubjectRepository(_context);
            }
            return _subjects;
        }
    }
    public ISubjectType SubjectTypes
    {
        get
        {
            if (_subejctTypes == null)
            {
                _subejctTypes = new SubjectTypeRepository(_context);
            }
            return _subejctTypes;
        }
    }
    public ITeacher Teachers
    {
        get
        {
            if (_teachers == null)
            {
                _teachers = new TeacherRepository(_context);
            }
            return _teachers;
        }
    }


    //jwt
    public IRoleRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RoleRepository(_context);
            }
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }

    public int Save()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}