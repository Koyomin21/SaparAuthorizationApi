using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaparAuthorization.Domain.Models;

namespace SaparAuthorization.Domain.Repositories.UsersRepository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateUser(User user)
        {
            if (user.Id > 0)
                throw new Exception("Cannot insert user with id > 0");

            Create(user);
        }

        public User FindByEmail(string email)
        {
            return FindByCondition(u => u.Email == email).Include(u => u.Role).FirstOrDefault();
        }

        public User FindById(long id)
        {
            return FindByCondition(u => u.Id == id).FirstOrDefault();
        }
    }
}
