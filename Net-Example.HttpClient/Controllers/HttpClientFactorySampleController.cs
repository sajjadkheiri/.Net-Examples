using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net_Example.HttpClient.Models;
using Newtonsoft.Json;

namespace Net_Example.HttpClient.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HttpClientFactorySampleController : ControllerBase
    {
        private readonly IHttpClientFactory _factory;

        public HttpClientFactorySampleController(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using (var client = _factory.CreateClient())
            {
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                var result = await client.GetStringAsync("/posts");
                var finalResult = JsonConvert.DeserializeObject<List<Post>>(result);

                return Ok(finalResult);
            }
        }
    }
}
