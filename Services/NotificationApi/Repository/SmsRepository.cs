using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Threading.Tasks;
using NotificationApi.model;

public class TwilioSmsService
{
    private readonly string _accountSid;
    private readonly string _authToken;
    private readonly string _twilioPhoneNumber;

    public TwilioSmsService(string accountSid, string authToken, string twilioPhoneNumber)
    {
        _accountSid = accountSid;
        _authToken = authToken;
        _twilioPhoneNumber = twilioPhoneNumber;
    }

    public async Task<string> SendSmsAsync(SmsRequest smsRequest)
    {
        TwilioClient.Init(_accountSid, _authToken);

        var message = await MessageResource.CreateAsync(
            body: smsRequest.Message,
            from: new PhoneNumber(_twilioPhoneNumber),
            to: new PhoneNumber(smsRequest.ToPhoneNumber)
        );

        return message.Sid;  // Return message SID as a confirmation
    }
}
