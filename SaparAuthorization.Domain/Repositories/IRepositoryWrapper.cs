using SaparAuthorization.Domain.Repositories.UsersRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Domain.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository UserRepository { get; }
        void Save();
    }
}
