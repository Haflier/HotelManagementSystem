using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.City;
using api.DTOs.Hotel;
using api.Models;
using AutoMapper;

namespace api.Configuration 
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<City, CityDto>().ReverseMap();

            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, HotelDetailDto>().ReverseMap();
            CreateMap<Hotel, HotelBaseDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelRequestDto>().ReverseMap();
            CreateMap<Hotel, UpdateHotelRequestDto>().ReverseMap();
        }
    }
}