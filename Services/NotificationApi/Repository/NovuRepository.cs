using NotificationApi.model;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace NotificationApi.Repository
{


    public class NovuService
    {
        private readonly HttpClient _httpClient;
        private const string NovuApiUrl = "https://api.novu.co/v1/events/trigger";
        private const string NovuApiKey = "9aaebc3f3305d038856b75e525a267bb";

        // Constructor injects HttpClient
        public NovuService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpContent> TriggerEventAsync(Details details)
        {
            var payload = new
            {
                name = "welcome-onboarding-email", 
                to = new
                {
                    subscriberId = details.id,
                    email = details.email,
                    phone = "+91"+details.phone
                },
                payload = new
                {
                    otp = "",
                },
                bridgeUrl = "https://5adb7dd7-e385-4f22-be5f-a1cfeea75a72.novu.sh/api/novu"
            };

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, NovuApiUrl)
            {
                Headers = { { "Authorization", $"ApiKey {NovuApiKey}" } },
                Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json")
            };

            // Send request
            var response = await _httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                //Console.WriteLine("Event triggered successfully.");
                return response.Content;
            }
            else
            {
                Console.WriteLine($"Failed to trigger event: {response.ReasonPhrase}");
                return response.Content;
            }
        }

        //public async Task TriggerEventOTPAsync(Details details)
        //{
        //    var payload = new
        //    {
        //        name = "welcomeOtp", // Event name
        //        to = new
        //        {
        //            subscriberId = details.id,
        //            email = details.email,
        //            phone = details.phone
        //        },
        //        payload = new
        //        {
        //            otp = details.otp,
        //        },
        //        bridgeUrl = "https://5adb7dd7-e385-4f22-be5f-a1cfeea75a72.novu.sh/api/novu"
        //    };

        //    // Create HTTP request message
        //    var requestMessage = new HttpRequestMessage(HttpMethod.Post, NovuApiUrl)
        //    {
        //        Headers = { { "Authorization", $"ApiKey {NovuApiKey}" } },
        //        Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json")
        //    };

        //    // Send request
        //    var response = await _httpClient.SendAsync(requestMessage);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        // Successfully triggered the event
        //        Console.WriteLine("Event triggered successfully.");
        //    }
        //    else
        //    {
        //        // Handle failure
        //        Console.WriteLine($"Failed to trigger event: {response.ReasonPhrase}");
        //    }
        //}




        public async Task<HttpContent> TriggerEventOTPAsync(Details details)
        {
            var payload = new
            {
                name = "welcomOtp",  // Event name
                to = new
                {
                    subscriberId = details.id,  // Subscriber ID
                    email = details.email,
                    phone = "+91"+details.phone
                },
                payload = new
                {
                    otp = details.otp  // OTP value
                },
                bridgeUrl = "https://5adb7dd7-e385-4f22-be5f-a1cfeea75a72.novu.sh/api/novu"  // Bridge URL
            };

            // Create HTTP request message
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, NovuApiUrl)
            {
                // Add headers
                Headers = { { "Authorization", $"ApiKey {NovuApiKey}" } },
                Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json") // Serialize the payload to JSON
            };

           
                // Send the HTTP request
                var response = await _httpClient.SendAsync(requestMessage);

                if (response.IsSuccessStatusCode)
                {
                    // Log success
                    //Console.WriteLine("Event triggered successfully.");
                    return response.Content;
                }
                else
                {
                    // Log failure with the reason
                    //Console.WriteLine($"Failed to trigger event: {response.ReasonPhrase}");
                    return response.Content;
                }
            
            
            
        }
    }

}
