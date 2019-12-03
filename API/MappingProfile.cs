﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();

            CreateMap<Validation, ValidationDto>();
            CreateMap<ValidationForCreationDto, Validation>();

            CreateMap<Component, ComponentDto>();
            CreateMap<ComponentForCreationDto, Component>();

            CreateMap<Categorie, CategorieDto>();
            CreateMap<CategorieForCreationDto, Categorie>();

        }
    }
}
