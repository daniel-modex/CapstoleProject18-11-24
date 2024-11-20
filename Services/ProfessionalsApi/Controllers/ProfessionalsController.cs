using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessionalsApi.Data;
using ProfessionalsApi.Models;
using ProfessionalsApi.Repository.IRepository;

namespace ProfessionalsApi.Controllers
{
    [Route("api/Services")]
    [ApiController]
    public class ProfessionalsController : ControllerBase
    {
        private readonly IProfessionalRepository _professionalRepository;

        public ProfessionalsController(IProfessionalRepository professionalRepository)
        {
            _professionalRepository = professionalRepository;
        }

        // GET: api/Professionals
        [Authorize(Roles ="admin")]
        [HttpGet("GetAllProfessionals")]
        public async Task<ActionResult<ResponseDTO>> GetProfessionals()
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _professionalRepository.GetAllProfessionals(),
            };

            return Ok(response);
        }

        // GET: api/Professionals/5
        [Authorize]
        [HttpGet("GetProfessional/{id}")]
        public async Task<ActionResult<ResponseDTO>> GetProfessionals(int id)
        {
            var professionals = await _professionalRepository.GetProfessional(id);

            if (professionals == null)
            {
                return NotFound();
            }

            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = professionals,
            };

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetProfessionalByUserName/{userName}")]
        public async Task<ActionResult<ResponseDTO>> GetProfessionalsByUserName(string userName)
        {
            var professionals = await _professionalRepository.GetProfessionalByUserName(userName);

            if (professionals == null)
            {
                return NotFound();
            }

            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = professionals,
            };

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetProfessionalsByDomain/{domain}")]
        public async Task<ActionResult<ResponseDTO>> GetProfessionalsByDomain(string domain)
        {
            var professionals = await _professionalRepository.GetProfessionalsByDomain(domain);

            if (professionals == null)
            {
                return NotFound();
            }

            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = professionals,
            };

            return Ok(response);
        }

        // PUT: api/Professionals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("updateProfile/{id}")]
        public async Task<ActionResult<ResponseDTO>> PutProfessionals(int id, UpdateProfile updateProfile)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _professionalRepository.PutProfessional(id, updateProfile),
            };

            return Ok(response);
        }

        // POST: api/Professionals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPost("Register")]
        public async Task<ActionResult<ResponseDTO>> PostProfessionals(RegistrationRequestDTO registrationRequest)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _professionalRepository.PostProfessional(registrationRequest),
            };

            return Ok(response);
        }

        // DELETE: api/Professionals/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO>> DeleteProfessionals(int id)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _professionalRepository.DeleteProfessional(id),
            };

            return Ok(response);
        }


        [Authorize(Roles ="admin")]
        [HttpPut("ConfirmService")]
        public async Task<ActionResult<ResponseDTO>> ConfirmService(ConfirmService confirm)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _professionalRepository.ConfirmResponse(confirm),
            };

            return Ok(response);
        }

        [Authorize(Roles ="provider")]
        [HttpPut("StatusChange")]
        public async Task<ActionResult<ResponseDTO>> StatusChange([FromQuery]int id, [FromBody]bool status)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _professionalRepository.ChangeStatus(id, status),
            };

            return Ok(response);
        }


    }
    public class ConfirmService
    {
        public int Id { get; set; }
        public decimal Rating { get; set; }
        public bool Status { get; set; }
    }
}
