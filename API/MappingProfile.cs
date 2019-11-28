using AutoMapper;
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
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerForCreationDto, Owner>();

            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();

            CreateMap<Validation, ValidationDto>();
            CreateMap<ValidationForCreationDto, Validation>();

            CreateMap<Account, AccountDto>();


        }
    }
}
