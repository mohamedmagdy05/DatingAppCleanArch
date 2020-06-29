using DatingAppCleanArch.Domain.Entities;
using DatingAppCleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCleanArch.Persistence.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRrepository
    {
        public UserRepository(DatingAppContext Context) : base(Context)
        {
        }
    }
}
