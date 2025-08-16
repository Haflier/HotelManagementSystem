using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces 
{
    public interface IReservationRepository : IGenericRepository<Reservation>
    {
        Task<Room> GetRoomAsync(int id);
        Task<List<DateTime>> DateTimeCalculation(DateTime checkinDate, DateTime checkOutDate);
    }
}