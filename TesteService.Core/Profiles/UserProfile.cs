using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TesteService.Core.Commands;
using TesteService.Core.Entities;
using TesteService.Core.Responses;

namespace TesteService.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AddUser, TUser>().ReverseMap();
            CreateMap<UsersResponse, TUser>().ReverseMap();
                    }
    }
}
