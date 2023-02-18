using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaparAuthorization.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Authorized endpoint!";
        }

        [HttpGet]
        [Route("/adm")]
        [Authorize(Roles = "Admin")]
        public string AdminOnly()
        {
            return "Admin Only Endpoint";
        }
    }
}
