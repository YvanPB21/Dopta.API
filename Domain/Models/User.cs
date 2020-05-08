using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email_address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Profile Profile { get; set; }

        public IList<Post> Posts { get; set; } = new List<Post>();
        public IList<Candidate> Candidates { get; set; } = new List<Candidate>();
    }
}
