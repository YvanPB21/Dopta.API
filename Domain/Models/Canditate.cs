using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Models
{
    public class Candidate
    {
       
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int AdopterId { get; set; }
        public User Adopter { get; set; }

    }
}
