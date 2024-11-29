using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Net_Example.HttpClient.Models;

namespace Net_Example.HttpClient.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HttpClientSampleController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                var result = await client.GetStringAsync("/posts");
                var finalResult = JsonConvert.DeserializeObject<List<Post>>(result);

                return Ok(finalResult);
            }
        }
    }
}
