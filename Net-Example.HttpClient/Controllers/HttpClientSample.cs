using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net_Example.HttpClient.Models;
using Newtonsoft.Json;

namespace Net_Example.HttpClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientSample : ControllerBase
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                var response = await client.GetStringAsync("/posts");
                var result = JsonConvert.DeserializeObject<List<Post>>(response);

                return Ok(result);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                var response = await client.GetStringAsync($"/posts/1");
                var result = JsonConvert.DeserializeObject<Post>(response);

                return Ok(result);
            }
        }
    }
}
