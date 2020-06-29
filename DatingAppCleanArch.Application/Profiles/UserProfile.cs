using AutoMapper;
using DatingAppCleanArch.Application.Dtos;
using DatingAppCleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCleanArch.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
         CreateMap<User,UserModel>();
        }


    }
}
