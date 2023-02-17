using SaparAuthorization.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Business.Services.Users
{
    public interface IUserService
    {
        UserModel GetUserByEmail(string email);
    }
}
