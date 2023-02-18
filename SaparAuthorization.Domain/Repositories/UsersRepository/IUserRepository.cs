using SaparAuthorization.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Domain.Repositories.UsersRepository
{
    public interface IUserRepository
    {
        User FindById(long id);
        User FindByEmail(string email);

        void CreateUser(User user);
    }
}
