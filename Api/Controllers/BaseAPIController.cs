using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
        public void Bruh()
        {
            Console.WriteLine("Ahhhhhhhhhhhhhhhh, I hate myself!!!");
        }
    }
}