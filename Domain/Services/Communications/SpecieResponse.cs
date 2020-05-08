using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services.Communications
{
    public class SpecieResponse : BaseResponse
    {
        public Specie Specie { get; private set; }
        public SpecieResponse(bool success,string message,Specie specie) : base(success,message)
        {
            Specie = specie;
        }

        public SpecieResponse(string message) : this(false, message, null) { }

        public SpecieResponse (Specie specie ) : this(true, string.Empty, specie) { }

    }
}
