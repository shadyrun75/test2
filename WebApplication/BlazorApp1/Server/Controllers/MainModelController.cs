using Microsoft.AspNetCore.Mvc;
using ModelsLib;
using Newtonsoft.Json;
using RestSharp;

namespace BlazorApp1.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainModelController : ControllerBase
    {
        private readonly ILogger<MainModelController> _logger;

        public MainModelController(ILogger<MainModelController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<DatabaseMainModel> Get(int offset = 0, int count = 25)
        {
            var client = new RestClient("https://localhost:7118/mainmodel");
            var request = new RestRequest("", Method.Get);
            request.AddQueryParameter("offset", offset.ToString());
            request.AddQueryParameter("count", count.ToString());
            var response = client.GetAsync(request).Result;
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<IEnumerable<DatabaseMainModel>>(response.Content);
            }
            return Enumerable.Empty<DatabaseMainModel>();
        }
    }
}