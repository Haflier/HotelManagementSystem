using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.ApiUser;
using api.DTOs.City;
using api.DTOs.Hotel;
using api.DTOs.Reservation;
using api.DTOs.Room;
using api.DTOs.Service;
using api.DTOsa.Reservation;
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
            CreateMap<Hotel, HotelForCityDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelRequestDto>().ReverseMap();
            CreateMap<Hotel, UpdateHotelRequestDto>().ReverseMap();

            CreateMap<ApiUser, ApiUserDto>().ReverseMap();
            CreateMap<ApiUser, AuthResponseDto>().ReverseMap();
            CreateMap<ApiUser, LoginDto>().ReverseMap();

            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<Room, RoomBaseDto>().ReverseMap();
            CreateMap<Room, RoomDetailDto>().ReverseMap();
            CreateMap<Room, CreateRoomRequestDto>().ReverseMap();
            CreateMap<Room, UpdateRoomRequestDto>().ReverseMap();
            CreateMap<Room, RoomForHotelDto>().ReverseMap();

            CreateMap<RoomService, RoomServiceDto>().ReverseMap();

            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<Service, ServiceBaseDto>().ReverseMap();
            CreateMap<Service, ServiceDetailDto>().ReverseMap();
            CreateMap<Service, CreateServiceRequestDto>().ReverseMap();
            CreateMap<Service, UpdateServiceRequestDto>().ReverseMap();

            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Reservation, ReservationBaseDto>().ReverseMap();
            CreateMap<Reservation, CreateReservationRequestDto>().ReverseMap();
            CreateMap<Reservation, UpdateReservationRequestDto>().ReverseMap();
            CreateMap<Reservation, ReservationForRoomDto>().ReverseMap();
        }
    }
}