using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Resources
{
    public class CandidateResource
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int AdopterId { get; set; }
        public User Adopter { get; set; }
    }
}
