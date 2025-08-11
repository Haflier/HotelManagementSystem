using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.City;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepo;
        public CityController(ICityRepository cityRepo, IMapper mapper)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            var cityModels = await _cityRepo.GetAllDetailsAsync();

            if (cityModels == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<CityDto>>(cityModels));
        }
    }
}