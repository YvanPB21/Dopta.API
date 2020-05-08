using AutoMapper;
using Dopta.API.Domain.Models;
using Dopta.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveSpecieResource, Specie>();
            CreateMap<SavePetResource, Pet>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SavePostResource, Post>();
            //CreateMap<SaveCandidateResource, Candidate>();

        }
    }
}
