using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Service;
using api.Interfaces;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepos;
        private readonly IMapper _mapper;
        public ServiceController(IServiceRepository serviceRepos, IMapper mapper)
        {
            _serviceRepos = serviceRepos;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var serviceModels = await _serviceRepos.GetAllAsync();

            if (serviceModels == null)
            {
                return NotFound();
            }

            var servicesDto = _mapper.Map<List<ServiceDto>>(serviceModels);
            return Ok(servicesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var serviceModel = await _serviceRepos.GetAsync(id);

            if (serviceModel == null)
            {
                return NotFound();
            }

            var serviceDto = _mapper.Map<ServiceDto>(serviceModel);
            return Ok(serviceDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateServiceRequestDto serviceDto)
        {
            var serviceModel = await _serviceRepos.AddAsync(_mapper.Map<Service>(serviceDto));
            var service = _mapper.Map<ServiceDto>(serviceModel);
            return CreatedAtAction(nameof(Get), new { id = serviceModel.Id }, service);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, ServiceDto serviceDto)
        {
            if (id != serviceDto.Id) return BadRequest("Service Ids do not match");

            var serviceModel = await _serviceRepos.GetAsync(id);
            if (serviceModel == null) return BadRequest("Service not found");

            _mapper.Map(serviceDto, serviceModel);

            try
            {
                await _serviceRepos.UpdateAsync(serviceModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _serviceRepos.Exists(id))
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
            await _serviceRepos.DeleteAsync(id);
            return NoContent();
        }
            
    }
}