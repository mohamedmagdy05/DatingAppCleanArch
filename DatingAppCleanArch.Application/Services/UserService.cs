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
        public Task<User> Add(User entity)
        {
            return _ctx.Add(entity);
        }

        public Task<User> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

   

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }

       IEnumerable<User> IBaseRepository<User>.GetAll()
        {
            return _ctx.GetAll();
        }
    }
}
