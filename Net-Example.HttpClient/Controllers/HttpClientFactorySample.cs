using Microsoft.AspNetCore.Mvc;
using Net_Example.HttpClient.Models;
using Newtonsoft.Json;

namespace Net_Example.HttpClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientFactorySample : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpClientFactorySample(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            using (var client = _clientFactory.CreateClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                var response = await client.GetStringAsync("/posts");
                var result = JsonConvert.DeserializeObject<List<Post>>(response);

                return Ok(result);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            using (var client = _clientFactory.CreateClient("posts"))
            {
                var response = await client.GetStringAsync($"/posts/{id}");
                var result = JsonConvert.DeserializeObject<Post>(response);

                return Ok(result);
            }
        }
    }
}
