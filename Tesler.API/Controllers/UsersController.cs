using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog.Targets;
using Tesler.API.Models;
using Tesler.Core;
using Tesler.Core.DTO;
using Tesler.Core.Entities;
using Tesler.Core.Services;
using Tesler.Servise;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tesler.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(Roles = "Manager")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UsersController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/<UsersController>
        [HttpGet]
        
        public async Task<ActionResult> Get()
        {
            var users =await _userService.GetListAsync();
            var usersListDTO = _mapper.Map<IEnumerable<UserDTO>>(users);
            Console.WriteLine(usersListDTO);
            return Ok(usersListDTO);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var user =await _userService.GetByIdAsync(id);
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserPostModel user)
        {
            var userToAdd=new User {Name=user.Name,Role=user.Role,Email=user.Email,Password=user.Password };
            var newUser =await _userService.AddAsync(userToAdd);
            return Ok(newUser);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User user)
        {
            var updateUser =await _userService.UpdateAsync(user);
            return Ok(updateUser);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
           await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
