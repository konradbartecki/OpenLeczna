using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLeczna.DTOs;
using OpenLeczna.Models;

namespace OpenLeczna.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<City, CityDTO>();
            AutoMapper.Mapper.CreateMap<Carrier, CarrierDTO>();
            AutoMapper.Mapper.CreateMap<Departure, DepartureDTO>();
            AutoMapper.Mapper.CreateMap<Schedule, ScheduleDTO>();
            AutoMapper.Mapper.CreateMap<Schedule, ScheduleDetailsDTO>();
            AutoMapper.Mapper.CreateMap<Station, StationDto>();
            AutoMapper.Mapper.CreateMap<Station, StationDetailsDto>();

        }
    }
}
