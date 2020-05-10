using AutoMapper;
using Dopta.API.Domain.Models;
using Dopta.API.Domain.Services;
using Dopta.API.Resources;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("/api/species/{specieId}/pets")]
    public class SpeciePetsController:Controller
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public SpeciePetsController(IPetService petService, IMapper mapper)
        {
            _petService = petService;
            _mapper = mapper;
        }

        
    }
}
