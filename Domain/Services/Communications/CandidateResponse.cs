using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services.Communications
{
    public class CandidateResponse : BaseResponse<Candidate>
    {
        
        public CandidateResponse(Candidate candidate) : base(candidate)
        {
           
        }

        public CandidateResponse(string message) : base(message) { }
    }
}
