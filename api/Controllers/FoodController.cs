using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Food;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _repo;
        private readonly IMapper _mapper;
        public FoodController(IFoodRepository foodRepo, IMapper mapper)
        {
            _repo = foodRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            var foodModels = await _repo.GetAllAsync();

            if (foodModels == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<FoodDto>>(foodModels));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var foodModel = await _repo.GetAsync(id);

            if (foodModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FoodDto>(foodModel));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFoodRequestDto foodDto)
        {
            if (foodDto == null) return BadRequest("Food object is null");
            
            var foodModel = await _repo.AddAsync(_mapper.Map<Food>(foodDto));
            var food = _mapper.Map<FoodDto>(foodModel);
            return CreatedAtAction(nameof(Get), new { id = foodModel.Id }, food);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, FoodDto foodDto)
        {
            if (id != foodDto.Id) return BadRequest("Food Ids do not match");

            var foodModel = await _repo.GetAsync(id);
            if (foodModel == null) return BadRequest("Food not found");

            _mapper.Map(foodDto, foodModel);

            try
            {
                await _repo.UpdateAsync(foodModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _repo.Exists(id))
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
            await _repo.DeleteAsync(id);

            if (!await _repo.Exists(id))
            {
                return NotFound("Food not found.");
            }

            return NoContent();
        }
    }
}