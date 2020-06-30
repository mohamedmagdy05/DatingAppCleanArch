using DatingAppCleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCleanArch.Application.Dtos
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FristName { get; set; }
        public String LastName { get; set; }

        public int Age { get; set; }
        public string Email { get; set; }

        public string Url { get; set; }

        public int GroupId { get; set; }
        //public Group Group { get; set; }
    }
}
