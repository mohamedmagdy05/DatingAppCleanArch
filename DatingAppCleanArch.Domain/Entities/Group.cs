using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCleanArch.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
