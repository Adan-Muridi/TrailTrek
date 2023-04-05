using Microsoft.AspNetCore.Mvc;

namespace TrailTrek.Api.Controllers
{
    [Route("[controller]")]
    public class DinnersController : ApiController
    {
        public IActionResult ListDinner() 
        {
            return Ok(Array.Empty<string>());
        }
    }
}
