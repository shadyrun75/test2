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
        public IEnumerable<DatabaseMainModel> Get(int offset = 0, int count = 25, int? code = null, string? value = null)
        {
            var client = new RestClient("https://localhost:7118/mainmodel");
            var request = new RestRequest("", Method.Get);
            request.AddQueryParameter("offset", offset.ToString());
            request.AddQueryParameter("count", count.ToString());
            if (code != null)
                request.AddQueryParameter("code", code.ToString());
            if (value?.Length > 0)
                request.AddQueryParameter("value", value);
            var response = client.GetAsync(request).Result;
            if (response.IsSuccessful)
            {
                var totalitems = response.Headers.FirstOrDefault(x => x.Name == "totalitems")?.Value.ToString();
                Response.Headers.Add("totalitems", new Microsoft.Extensions.Primitives.StringValues(totalitems));
                return JsonConvert.DeserializeObject<IEnumerable<DatabaseMainModel>>(response.Content);
            }
            return Enumerable.Empty<DatabaseMainModel>();
        }

        [HttpPost]
        public void Post(IEnumerable<MainModel> data)
        {
            var client = new RestClient("https://localhost:7118/mainmodel");
            var request = new RestRequest("", Method.Post);
            request.AddBody(data);
            var response = client.PostAsync(request).Result;
            if (!response.IsSuccessful)
                throw new Exception(response.Content);
        }
    }
}