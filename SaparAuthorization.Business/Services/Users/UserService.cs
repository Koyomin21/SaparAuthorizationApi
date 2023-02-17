using AutoMapper;
using AutoMapper.Configuration;
using SaparAuthorization.Business.Models;
using SaparAuthorization.Domain.Models;
using SaparAuthorization.Domain.Repositories;
using SaparAuthorization.Domain.Repositories.UsersRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Business.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
       
        public UserService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }
        public UserModel GetUserByEmail(string email)
        {
            IUserRepository userRepository = _repositoryWrapper.UserRepository;
            User user = userRepository.FindByEmail(email);

            return _mapper.Map<UserModel>(user);
        }

        public bool isValid(UserModel userModel)
        {
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(userModel);
            var results = new List<ValidationResult>();

            return Validator.TryValidateObject(userModel, context, results, true);

        }
    }
}
