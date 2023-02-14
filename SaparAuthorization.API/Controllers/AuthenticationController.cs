using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaparAuthorization.Domain.Repositories;

namespace SaparAuthorization.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AuthenticationController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public String Get()
        {
            string email = _repositoryWrapper.UserRepository.FindById(1)?.Email ?? "NOT FOUND";
            return email;
        }
    }
}
