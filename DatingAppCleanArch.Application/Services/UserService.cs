using DatingAppCleanArch.Application.Dtos;
using DatingAppCleanArch.Application.Interfaces;
using DatingAppCleanArch.Domain.Entities;
using DatingAppCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCleanArch.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRrepository _ctx;

        public UserService(IUserRrepository context)
        {
            _ctx = context;
        }

        public async Task<UserModel> AddUser(UserModel UserData)
        {
            var user = new User() { 
            FristName = UserData.FristName,
            LastName = UserData.LastName,
            Age = UserData.Age,
            Url = UserData.Url,
            GroupId = UserData.GroupId
            };

            var Data = await _ctx.Add(user);
           return new UserModel() { Id = Data.Id, FristName = Data.FristName };
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var Data = await _ctx.GetAllusers();
            
            var Result = Data.Select(u => new UserModel
            {
               Id  = u.Id,
               FristName = u.FristName,
               LastName = u.LastName,
               Age = u.Age,
               GroupId = u.GroupId,
               
            });


            return Result;
        }

        
    }
}
