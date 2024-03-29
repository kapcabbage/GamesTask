﻿using AutoMapper;
using BusinessLogic.Dtos;
using DataAccess.POCO;

namespace WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameDto>();
            CreateMap<Event, EventDto>()
                .ForMember(dsc=>dsc.EventType, opt => opt.MapFrom(src=>src.EventType.Name));
        }
    }
}
