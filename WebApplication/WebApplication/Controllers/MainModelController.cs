using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainModelController : ControllerBase
    {

        [HttpGet]
        //[DisableCors]
        public IEnumerable<InterfacesLib.IDatabaseMainModel> Index(int offset = 0, int count = 25, int? code = null, string? value = null)
        {
            int totalcount = 0;
            var result = DBWorker.Database.Select(ref totalcount, offset, count, code, value);
            Response.Headers.Add("totalitems", new Microsoft.Extensions.Primitives.StringValues($"{totalcount}"));
            return result;
        }

        [HttpPost]
        public IActionResult Insert([FromBody]IEnumerable<ModelsLib.MainModel> mainmodels)
        {
            try
            {
                DBWorker.Database.Clear();
                DBWorker.Database.Insert(mainmodels);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
