﻿using Pylon.DAL;

namespace Pylon.BL.Mapping
{
    public class UserProfileMapping : AutoMapper.Profile
    {
        public UserProfileMapping()
        {
            CreateMap<UserDTO, Profile>()
                .ForMember(dbe => dbe.Id, e => e.MapFrom(src => src.Id))
                .ForMember(dbe => dbe.FirstName, e => e.MapFrom(src => src.FirstName))
                .ForMember(dbe => dbe.LastName, e => e.MapFrom(src => src.LastName))
                .ForMember(dbe => dbe.CompanyName, e => e.MapFrom(src => src.CompanyName))
                .ForMember(dbe => dbe.Phone, e => e.MapFrom(src => src.Phone))
                .ReverseMap();
        }
    }
}