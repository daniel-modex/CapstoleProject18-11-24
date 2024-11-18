using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Models;
using UserApi.Repository.IRepository;

namespace UserApi.Controllers
{
    [Route("api/UserApi")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            new ResponseDTO();
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetUsers()
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _userRepository.GetAllUsers(),
            };

            return Ok(response);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO>> GetUser(int id)
        {

            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _userRepository.GetUser(id),
            };

            return Ok(response);
        }

        [HttpGet("ByUserName/{userName}")]
        public async Task<ActionResult<ResponseDTO>> GetUserByUserName(string userName)
        {

            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _userRepository.GetUserByUserName(userName),
            };

            return Ok(response);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<ActionResult<ResponseDTO>> PutUser(User user)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _userRepository.PutUser(user),
            };

            return Ok(response);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> PostUser(RegistrationRequestDTO registrationRequestDTO)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _userRepository.PostUser(registrationRequestDTO),
            };

            return Ok(response);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO>> DeleteUser(int id)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _userRepository.DeleteUser(id),
            };

            return Ok(response);
        }

        
    }
}
