using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int PosterId { get; set; }
        public User Poster { get; set; }
       
        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public DateTime Date_published { get; set; }
        public string Description { get; set; }
        public DateTime Date_adopted { get; set; }

        public IList<Candidate> Candidates { get; set; } = new List<Candidate>();

    }
}
