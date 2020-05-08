using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Resources
{
    public class CandidateResource
    {
        public PostResource Post { get; set; }
        public UserResource Adopter { get; set; }
    }
}
