using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using apiRepositories;
using AutoMapper;

namespace api.Repositories 
{
    public class DrinkRepository : GenericRepository<Drink>, IDrinkRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DrinkRepository(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}