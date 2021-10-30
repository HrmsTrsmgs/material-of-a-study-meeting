using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DefaultController : ControllerBase
    {

        [HttpGet]

        public IEnumerable<string> Hello([FromQuery] string? name)
            => new[] { $"Hello {name}!!" };
    }
}