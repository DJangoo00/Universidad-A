using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Repository
{
    public class PersonTypeRepository : GenericRepository<PersonType>, IPersonType
{
    private readonly ApiContext _context;
    public PersonTypeRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    }
}