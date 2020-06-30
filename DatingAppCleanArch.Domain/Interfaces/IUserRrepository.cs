using DatingAppCleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCleanArch.Domain.Interfaces
{
    public interface IUserRrepository : IBaseRepository<User>
    {
        Task<List<User>> GetAllusers();
    }
}
