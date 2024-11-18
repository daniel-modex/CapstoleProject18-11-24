using CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationApi.model;
using NotificationApi.Repository;

namespace NotificationApi.Controllers
{
    [Route("api/novu")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly NovuService _novuService;

        public NotificationsController(NovuService novuService)
        {
            _novuService = novuService;
        }

        // Endpoint to trigger the Novu event
        [HttpPost("send-welcome-email")]
        public async Task<ActionResult<ResponseDTO>> SendWelcomeEmail(Details details)
        {
            if (details == null || string.IsNullOrEmpty(details.email))
            {
                return BadRequest("Invalid subscriber data.");
            }

            // Call NovuService to trigger the event
            ResponseDTO response = new()
            {
                IsSuccessful = true,
                Result = await _novuService.TriggerEventAsync(details),
            };
            

            return Ok(response);
        }

        [HttpPost("send-otp")]
        public async Task<ActionResult<ResponseDTO>> SendOTP(Details details)
        {
            if (string.IsNullOrEmpty(details.email))
            {
                return BadRequest("Invalid subscriber data.");
            }

            // Call NovuService to trigger the event
            ResponseDTO response = new()
            {
                IsSuccessful = true,
                Result = await _novuService.TriggerEventOTPAsync(details),
            };
            

            return Ok(response);
        }
    }

    

}
