using SaparAuthorization.Domain.Repositories.UsersRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Domain.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IUserRepository _userRepository;
        private ApplicationDbContext _context;
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? new UserRepository(_context);
            }
        }

        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
