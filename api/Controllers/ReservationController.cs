using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using api.DTOs.Reservation;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepo;
        private readonly IMapper _mapper;
        public ReservationController(IReservationRepository reservationRepo, IMapper mapper)
        {
            _reservationRepo = reservationRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reservationModels = await _reservationRepo.GetAllAsync();

            if (reservationModels == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ReservationDto>>(reservationModels));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var reservationModel = await _reservationRepo.GetAsync(id);

            if (reservationModel == null)
            {
                return NotFound("Reservation not found");
            }

            return Ok(_mapper.Map<ReservationDto>(reservationModel));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateReservationRequestDto reservationDto)
        {
            var userId = User.FindFirst("uid")?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User ID not found in token.");

            var roomModel = await _reservationRepo.GetRoomAsync(reservationDto.RoomId);
            if (roomModel == null) return BadRequest("Room not found");

            if (reservationDto.CheckOutDate < reservationDto.CheckinDate)
                return BadRequest("End date must be greater than start date");

            if (reservationDto.CheckinDate <= DateTime.Now)
                return BadRequest("Start date must be greater than current date");

            var bookedDates = await _reservationRepo.DateTimeCalculation(reservationDto.CheckinDate, reservationDto.CheckOutDate);
            if (bookedDates.Any(date => roomModel.ReservedDates
                .Select(d => d.Date)
                .Contains(date.Date)))
            {
                return BadRequest("Some of the selected dates are already reserved.");
            }


            if (!(reservationDto.CheckOutDate < reservationDto.CheckinDate) && !(reservationDto.CheckinDate <= DateTime.Now)
                && !bookedDates.Any(date => roomModel.ReservedDates.Select(d => d.Date).Contains(date.Date)))
            {
                var reservationModel = _mapper.Map<Reservation>(reservationDto);
                reservationModel.ApiUserId = userId;
                reservationModel.PricePerDay = roomModel.BasePricePerDay;
                var resultModel = await _reservationRepo.AddAsync(reservationModel);
                var reservation = _mapper.Map<ReservationDto>(resultModel);
                return CreatedAtAction(nameof(Get), new { id = resultModel.Id }, reservation);
            }

            return StatusCode(500);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, UpdateReservationRequestDto reservationDto)
        {
            if (id != reservationDto.Id) return BadRequest("Reservation Ids do not match");

            var reservationModel = await _reservationRepo.GetAsync(id);
            if (reservationModel == null) return BadRequest("Reservation not found");

            _mapper.Map(reservationDto, reservationModel);

            try
            {
                await _reservationRepo.UpdateAsync(reservationModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _reservationRepo.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")] 
        public async Task<IActionResult> Delete(int id)
        {
            if (!await _reservationRepo.Exists(id))
            {
                return NotFound("Reservation not found.");
            }

            await _reservationRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}