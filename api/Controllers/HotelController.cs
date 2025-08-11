using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Hotel;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepo;
        private readonly IMapper _mapper;
        public HotelController(IHotelRepository hotelRepo, IMapper mapper)
        {
            _hotelRepo = hotelRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var hotelModels = await _hotelRepo.GetAllAsync();

            if (hotelModels == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<HotelDto>>(hotelModels));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var hotelModel = await _hotelRepo.GetAsync(id);

            if (hotelModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<HotelDto>(hotelModel));
        }

        [HttpGet("AllDetails/{id:int}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var hotelModel = await _hotelRepo.GetAsync(id);

            if (hotelModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<HotelDetailDto>(hotelModel));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHotelRequestDto hotelDto)
        {
            var HotelModel = await _hotelRepo.AddAsync(_mapper.Map<Hotel>(hotelDto));
            return CreatedAtAction(nameof(Get), new { id = HotelModel.Id }, HotelModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _hotelRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}