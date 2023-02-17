using AutoMapper;
using SaparAuthorization.Business.Models;
using SaparAuthorization.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Business
{
    public class EntityToModelMappingProfile: Profile
    {
        public EntityToModelMappingProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}
