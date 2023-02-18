using AutoMapper;
using SaparAuthorization.Api.DTOs;
using SaparAuthorization.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaparAuthorization.Api
{
    public class DtoToModelsMappingProfile: Profile
    {
        public DtoToModelsMappingProfile()
        {
            CreateMap<LoginDTO, AuthenticationModel>();
        }
    }
}
