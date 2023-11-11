using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace App.Repository
{
    public class GenderRepository : GenericRepository<Gender>, IGender
{
    private readonly ApiContext _context;
    public GenderRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    }
}