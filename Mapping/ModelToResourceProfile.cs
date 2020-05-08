using AutoMapper;
using Dopta.API.Domain.Models;
using Dopta.API.Resources;
using Dopta.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dopta.API.Controllers;

namespace Dopta.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Specie, SpecieResource>();

            CreateMap<Pet, PetResource>()
                .ForMember(src => src.Sex,
                opt => opt.MapFrom(src => src.Sex.ToDescriptionString()))
                .ForMember(src => src.Size,
                opt => opt.MapFrom(src => src.Size.ToDescriptionString()));

            CreateMap<User, UserResource>();

            CreateMap<Post, PostResource>();

            CreateMap<Candidate, CandidateResource>();

        }
    }
}
