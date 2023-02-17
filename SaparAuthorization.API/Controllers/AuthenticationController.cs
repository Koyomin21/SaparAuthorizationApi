using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaparAuthorization.Api.DTOs;
using SaparAuthorization.Business.Models;
using SaparAuthorization.Business.Services.Users;
using SaparAuthorization.Domain.Repositories;

namespace SaparAuthorization.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("login")]
        public UserModel Login(LoginDTO loginDTO)
        {
            if (!loginDTO.IsValid()) return new UserModel();

            UserModel userModel = _userService.GetUserByEmail(loginDTO.Email);
            return userModel;
        }
    }
}
