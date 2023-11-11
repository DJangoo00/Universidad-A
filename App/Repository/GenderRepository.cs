using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
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