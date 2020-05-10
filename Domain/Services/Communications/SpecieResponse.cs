using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services.Communications
{
    public class SpecieResponse : BaseResponse<Specie>
    {
        public SpecieResponse(Specie specie) : base(specie)
        {
        }

        public SpecieResponse(string message) : base(message) { }

    }
}
