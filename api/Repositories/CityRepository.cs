using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.City;
using api.Interfaces;
using api.Models;
using apiRepositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories 
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CityRepository(ApplicationDbContext context, IMapper mapper) 
        : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<CityDto> GetDetails(int id)
        {
            var cityDto = await _context.Cities.Include(q => q.Hotels)
                .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (cityDto == null)
            {
                return null;
            }

            return cityDto;
       }
    }
}