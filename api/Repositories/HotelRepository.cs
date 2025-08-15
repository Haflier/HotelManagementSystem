using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using apiRepositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories 
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public HotelRepository(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Hotel> GetDetails(int? id)
        {
            var hotelModel = await _context.Hotels
                .Include(r => r.Rooms)
                .ThenInclude(r => r.Reservations)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (hotelModel == null)
            {
                return null;
            }

            return hotelModel;
        }
    }
}