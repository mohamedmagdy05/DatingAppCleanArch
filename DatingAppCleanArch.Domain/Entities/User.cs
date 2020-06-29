using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatingAppCleanArch.Domain.Entities
{
    public class User
    {
        public User()
        {
        }
        public int Id { get; set; }
        public string FristName { get; set; }
        public String LastName { get; set; }

        public int Age { get; set; }
        public string Email { get; set; }

        public string Url { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
