using Microsoft.AspNetCore.Mvc;
using NotificationApi.model;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly EmailService _emailService;

    public EmailController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
    {
        if (emailRequest == null)
        {
            return BadRequest("Invalid email request.");
        }

        try
        {
            var response = await _emailService.SendEmailAsync(emailRequest);
            return Ok(new { message = "Email sent successfully.", response });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while sending the email.", error = ex.Message });
        }
    }





}
