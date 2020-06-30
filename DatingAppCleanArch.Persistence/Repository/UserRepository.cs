using DatingAppCleanArch.Domain.Entities;
using DatingAppCleanArch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCleanArch.Persistence.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRrepository
    {
        private readonly DatingAppContext _context;
        public UserRepository(DatingAppContext Context) : base(Context)
        {
            _context = Context;
        }

         public async Task<List<User>> GetAllusers()
        {

            return await _context.Set<User>().Include(u=>u.Group).ToListAsync();
        }
    }
}
