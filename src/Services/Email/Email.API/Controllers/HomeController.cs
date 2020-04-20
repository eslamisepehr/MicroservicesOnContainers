using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Email.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Index()
        {
            return Ok("Hello Email Microservice :)");
        }
    }
}