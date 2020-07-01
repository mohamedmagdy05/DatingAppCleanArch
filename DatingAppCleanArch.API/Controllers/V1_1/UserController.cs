using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingAppCleanArch.Application.Dtos;
using DatingAppCleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppCleanArch.API.Controllers.V1_1
{
    [ApiVersion("1.1")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]

    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _ctx;


        public UserController(IUserService ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(typeof(List<UserModel>), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var users = await _ctx.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            //var userDtos = _mapper.Map<List<UserModel>>(users);

        }


        [HttpPost]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(typeof(UserModel), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddUsers([FromBody] UserModel user)
        {
            try
            {
                var Data = await _ctx.AddUser(user);
              


                return Ok(Data);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
