using BookingApi.Models;
using BookingApi.Repository.IRepository;
using CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApi.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet("UserName/{userName}")]
        public async Task<ActionResult<ResponseDTO>> GetAllByUserName(string userName)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _bookingRepository.GetAllByUserName(userName),
            };

            return Ok(response);
        }

        [HttpGet("Professional/{professionalName}")]
        public async Task<ActionResult<ResponseDTO>> GetAllByProfessionalName(string professionalName)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _bookingRepository.GetAllByProfessional(professionalName),
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO>> GetDetailsById(int id)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _bookingRepository.GetDetailsById(id),
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> SubmitBooking(BookingDetails booking)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _bookingRepository.PostBooking(booking),
            };

            return Ok(response);
        }

        [HttpPut("ServiceResponse")]
        public async Task<ActionResult<ResponseDTO>> ServiceProviderResponse(BookingResponse bookingResponse)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _bookingRepository.UpdateServiceResponse(bookingResponse),
            };

            return Ok(response);
        }

        [HttpPut("PaymentResponse")]
        public async Task<ActionResult<ResponseDTO>> PaymentResponse(BookingResponse bookingResponse)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _bookingRepository.UpdatePaymentResponse(bookingResponse),
            };

            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ResponseDTO>> CancelBooking(BookingDetails booking)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _bookingRepository.CancelBooking(booking),
            };

            return Ok(response);
        }
    }
}
