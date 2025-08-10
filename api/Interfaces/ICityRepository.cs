using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.City;
using api.Models;

namespace api.Interfaces 
{
    public interface ICityRepository : IGenericRepository<City>
    {
        Task<CityDto> GetDetails(int id);
    }
}