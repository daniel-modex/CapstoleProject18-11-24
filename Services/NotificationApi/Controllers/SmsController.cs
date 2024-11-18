using Microsoft.AspNetCore.Mvc;
using NotificationApi.model;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class SmsController : ControllerBase
{
    private readonly TwilioSmsService _twilioSmsService;

    public SmsController(TwilioSmsService twilioSmsService)
    {
        _twilioSmsService = twilioSmsService;
    }

    // POST api/sms/send
    [HttpPost("send")]
    public async Task<IActionResult> SendSms([FromBody] SmsRequest smsRequest)
    {
        if (smsRequest == null || string.IsNullOrEmpty(smsRequest.ToPhoneNumber) || string.IsNullOrEmpty(smsRequest.Message))
        {
            return BadRequest("Phone number and message are required.");
        }

        try
        {
            // Send the SMS using Twilio
            var messageSid = await _twilioSmsService.SendSmsAsync(smsRequest);
            return Ok(new { Message = "SMS sent successfully.", MessageSid = messageSid });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while sending the SMS.", Error = ex.Message });
        }
    }
}
