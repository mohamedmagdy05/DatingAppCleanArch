using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingAppCleanArch.Application.Dtos;
using DatingAppCleanArch.Application.Interfaces;
using DatingAppCleanArch.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppCleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _ctx;
        private readonly IMapper _mapper;

        public UserController(IUserService ctx , IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        [HttpGet]
        public IEnumerable<User> getall()
        {
            var users = _ctx.GetAll().ToList();
            //var userDtos = _mapper.Map<List<UserModel>>(users);
            return users;
        }
        //[HttpPost]
        //public async Task <User> AddUsers([FromBody] User user)
        //{

        //    return await _ctx.Add(user);
        //}
    }
}