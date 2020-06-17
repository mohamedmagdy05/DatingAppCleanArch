using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCleanArch.Persistence
{
    class DatingAppContext : DbContext
    {
        public DatingAppContext(DbContextOptions options) : base(options)
        {
        }
    }
}
