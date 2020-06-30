using DatingAppCleanArch.Application.Dtos;
using DatingAppCleanArch.Domain.Entities;
using DatingAppCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCleanArch.Application.Interfaces
{
    public interface IUserService 
    {

        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel> AddUser(UserModel user);
    }
}
