using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Migrations;
using api.Models;
using apiRepositories;
using AutoMapper;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories 
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ReservationRepository(ApplicationDbContext context, IMapper mapper)
        : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<DateTime>> DateTimeCalculation(DateTime checkinDate, DateTime checkOutDate)
        {
            var totalNights = (checkOutDate - checkinDate).Days;
            List<DateTime> BookedDates = new List<DateTime>();

            BookedDates.Append(checkinDate);
            for (var day = 1; day < totalNights; day++)
            {
                BookedDates.Append(checkinDate.AddDays(1));
            }

            return Task.FromResult(BookedDates);
        }

        public async Task<Room?> GetRoomAsync(int id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}