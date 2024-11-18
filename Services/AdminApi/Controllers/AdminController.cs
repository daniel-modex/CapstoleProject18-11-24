
using CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AdminApi.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<ResponseDTO>> GetUsers()
        {
            var client = _httpClientFactory.CreateClient();
            var userApiURL = "https://localhost:7021/api/Users";
            var response = await client.GetAsync(userApiURL);
             

            ResponseDTO responseDTO = new()
            {
                Result =  JsonConvert.DeserializeObject<List<UserDTO>>(await response.Content.ReadAsStringAsync()),
                IsSuccessful = true
            };

            return Ok(responseDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDTO>> DeleteUser(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var userApiURL = $"https://localhost:7021/api/Users/{id}";
            var response = await client.DeleteAsync(userApiURL);

            

            ResponseDTO responseDTO = new()
            {
                Result = await response.Content.ReadAsStringAsync(),
                IsSuccessful = true
            };

            return Ok(responseDTO);
        }
    }
}
