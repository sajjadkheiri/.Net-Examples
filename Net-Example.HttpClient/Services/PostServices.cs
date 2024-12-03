using Microsoft.AspNetCore.Http.HttpResults;
using Net_Example.HttpClient.Models;
using Newtonsoft.Json;

namespace Net_Example.HttpClient.Services;

public class PostServices
{
    private readonly System.Net.Http.HttpClient _httpClient;

    public PostServices(System.Net.Http.HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5000");
    }

    public async Task<List<Post>> GetAllAsync()
    {
        var result = await _httpClient.GetStringAsync("/posts");
        return JsonConvert.DeserializeObject<List<Post>>(result);
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        var result = await _httpClient.GetStringAsync($"/posts/{id}");
        return JsonConvert.DeserializeObject<Post>(result);
    }
}