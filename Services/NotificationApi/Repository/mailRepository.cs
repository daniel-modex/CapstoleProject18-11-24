using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NotificationApi.Controllers;
using NotificationApi.model;

public class EmailService
{
    private readonly HttpClient _client;

    public EmailService(HttpClient client)
    {
        _client = client;
    }

    public async Task<string> SendEmailAsync(EmailRequest emailRequest)
    {
        var jsonContent = JsonConvert.SerializeObject(emailRequest);

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://mail-sender-api1.p.rapidapi.com/"),
            Headers =
            {
                { "x-rapidapi-key", "edd197b830msh28bcfd0164cc2f8p159fbajsn16f25322ddf9" },
                { "x-rapidapi-host", "mail-sender-api1.p.rapidapi.com" },
            },
            Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
        };

        // Send the request and get the response
        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode(); // Throws an exception if not successful

        // Read and return the response body
        return await response.Content.ReadAsStringAsync();
    }
}
