using SaparAuthorization.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Business.Services.Authentication
{
    public interface IAuthenticationService
    {
        UserModel AuthenticateUser(AuthenticationModel model);
        void CheckUserCredentials(AuthenticationModel authModel, UserModel userModel);
        string GenerateJwtToken(UserModel model);

        void RegisterUser(UserModel model);
    }
}
