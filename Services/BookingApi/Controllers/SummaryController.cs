using BookingApi.Repository;
using BookingApi.Repository.IRepository;
using CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly ISummaryRepository _summaryRepository;

        public SummaryController(ISummaryRepository summaryRepository)
        {
            _summaryRepository = summaryRepository;
        }

        [HttpGet("ProfessionalSummary/{pname}")]
        public async Task<ActionResult<ResponseDTO>> GetProfessionalSummary(string pname)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _summaryRepository.GetProfessionalSummary(pname),
            };

            return Ok(response);
        }

        [HttpGet("ServiceSummary/{sname}")]
        public async Task<ActionResult<ResponseDTO>> GetServiceSummary(string sname)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _summaryRepository.GetServiceSummary(sname),
            };

            return Ok(response);
        }
    }
}
