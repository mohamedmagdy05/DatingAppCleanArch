using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DatingAppCleanArch.Application.Dtos;
using DatingAppCleanArch.Application.Interfaces;
using DatingAppCleanArch.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppCleanArch.API.Controllers.V1_0
{
    //old version s
    [ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _ctx;
        //private readonly IMapper _mapper;

        public UserController(IUserService ctx )
        {
            _ctx = ctx;
            //_mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var users = await _ctx.GetAllUsers();
                return Ok (users);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //var userDtos = _mapper.Map<List<UserModel>>(users);
    }
      
    
    }
}