using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services.Communications
{
     public class PetResponse : BaseResponse<Pet>
     {
        public PetResponse(Pet pet) : base(pet)
        {
        }

        public PetResponse(string message) : base(message) { }
    }
}


