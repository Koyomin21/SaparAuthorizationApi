using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaparAuthorization.Api.DTOs;
using SaparAuthorization.Api.ViewModel;
using SaparAuthorization.Business.Models;
using SaparAuthorization.Business.Services.Authentication;
using SaparAuthorization.Business.Services.Users;
using SaparAuthorization.Domain.Repositories;


namespace SaparAuthorization.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;


        public AuthenticationController(IMapper mapper, IUserService userService, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _userService = userService;
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public bool Register(RegistrationDTO registrationDTO )
        {
            if(!registrationDTO.IsValid()) 
                throw new Exception("Validation error!");

            UserModel userModel = _mapper.Map<UserModel>(registrationDTO);
            _authenticationService.RegisterUser(userModel);

            return true;
        }

        [HttpPost("login")]
        public ApiResponseModel<TokenViewModel> Login(LoginDTO loginDTO)
        {
            if (!loginDTO.IsValid())
                throw new Exception("Validation error!");

            
            UserModel userModel = _authenticationService.AuthenticateUser(_mapper.Map<AuthenticationModel>(loginDTO));
            string token = _authenticationService.GenerateJwtToken(userModel);

            return ApiResponseModel<TokenViewModel>.Successfull(new TokenViewModel { Token = token});
        }

    }
}
