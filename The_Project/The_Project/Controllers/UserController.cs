using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Mock;
using Repository.Entities;
using Service.Interface;
using The_Project.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace The_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService<User> service;
        public UserController(IUserService<User> service)
        {   
            this.service = service;
        }
        // GET: api/<UserController>
        [HttpGet]
        public Task<List<User>> Get()
        {
            return service.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public Task<User> Get(int id)
        {
            return service.GetById(id);
        }

        //// POST api/<UserController>
        //[HttpPost]
        //public async Task<User> Post([FromBody] User value)
        //{
        //    return await service.AddItem(value);
        //}
        //[HttpPost("SignIn")]
        //public async Task<IActionResult> Post([FromBody] UserLogin userLogin)
        //{
        //    try
        //    {
        //        var user = await service.GetByPasswordAndEmail(userLogin.Password ,userLogin.Email);
        //        if (user == null)
        //        {
        //            return BadRequest("User not found");
        //        }

        //        var token = service.Generate(user);
        //        return Ok(new { Token = token });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    //var user = await service.GetByPasswordAndEmail(userLogin.Password, userLogin.Password);
        //    //if (user != null)
        //    //{
        //    //    var token = service.Generate(user);
        //    //    return Ok(token);
        //    //}
        //    //return BadRequest("user not found");

        //}
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserLogin userLogin)
        {
            if (userLogin == null || string.IsNullOrEmpty(userLogin.Password) || string.IsNullOrEmpty(userLogin.Email))
            {
                return BadRequest("Both Email and Password are required.");
            }

            var user = await service.GetByPasswordAndEmail(userLogin.Password, userLogin.Email);
            if (user == null)
            {
                return BadRequest("User not found");
            }

            var token = service.Generate(user);
            return Ok(new { Token = token });
        }


        [HttpPost("SignUp")]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            await service.AddItem(user);
            var token = service.Generate(user);
            TokenAndName tokenAndName = new TokenAndName(token, user.Name);
            return Ok(tokenAndName);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User value)
        {
            await service.UpDateItem(id, value);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteItem(id);
        }
    }
}
