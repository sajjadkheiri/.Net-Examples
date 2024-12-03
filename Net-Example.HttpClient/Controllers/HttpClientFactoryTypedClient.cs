using Microsoft.AspNetCore.Mvc;
using Net_Example.HttpClient.Services;

namespace Net_Example.HttpClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientFactoryTypedClient : ControllerBase
    {
        private readonly PostServices _postServices;

        public HttpClientFactoryTypedClient(PostServices postServices)
        {
            _postServices = postServices;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postServices.GetAllAsync());
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _postServices.GetByIdAsync(id));
        }
    }
}