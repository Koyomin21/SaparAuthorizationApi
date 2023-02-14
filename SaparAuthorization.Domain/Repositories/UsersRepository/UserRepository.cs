using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SaparAuthorization.Domain.Models;

namespace SaparAuthorization.Domain.Repositories.UsersRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User FindById(long id)
        {
            return this.FindByCondition(u => u.Id == id).FirstOrDefault();
        }
    }
}
