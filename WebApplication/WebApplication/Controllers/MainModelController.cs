using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainModelController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<InterfacesLib.IDatabaseMainModel> Index(int offset = 0, int count = 25, int? code = null, string? value = null)
        {
            return DBWorker.Database.Select(offset, count, code, value); 
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
