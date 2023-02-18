using DevOne.Security.Cryptography.BCrypt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SaparAuthorization.Business.Models;
using SaparAuthorization.Business.Services.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace SaparAuthorization.Business.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthenticationService(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public UserModel AuthenticateUser(AuthenticationModel model)
        {
            UserModel userModel = _userService.GetUserByEmail(model.Email);

            if (userModel is null)
                throw new Exception("User not found with such Email");

            CheckUserCredentials(model, userModel);

            return userModel;
        }

        public void CheckUserCredentials(AuthenticationModel authModel, UserModel userModel)
        {
            if (!BCryptHelper.CheckPassword(authModel.Password, userModel.Password))
                throw new Exception("Bad Credentials");

        }

        public string GenerateJwtToken(UserModel model)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: new List<Claim>
                {
                    new Claim (ClaimTypes.NameIdentifier, $"{model.Id}"),
                    new Claim (ClaimTypes.Email, model.Email),
                    new Claim (ClaimTypes.Role, model.Role.RoleName)
                },
                expires: DateTime.UtcNow.AddMinutes(1),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }
    }
}
