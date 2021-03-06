﻿using System;
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
    // older version
    [ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _ctx;

        public UserController(IUserService ctx )
        {
            _ctx = ctx;
         
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var users = await _ctx.GetAllUsers();
                //var userDtos = _mapper.Map<List<UserModel>>(users);
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