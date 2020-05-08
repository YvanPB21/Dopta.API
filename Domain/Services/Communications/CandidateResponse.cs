using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Services.Communications
{
    public class CandidateResponse : BaseResponse
    {
        public Candidate Candidate { get; private set; }
        public CandidateResponse(bool success, string message, Candidate candidate) : base(success, message)
        {
            Candidate = candidate;
        }

        public CandidateResponse(string message) : this(false, message, null) { }
               
        public CandidateResponse(Candidate candidate) : this(true, string.Empty, candidate) { }
    }
}
