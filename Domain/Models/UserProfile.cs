using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Dni { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //falta gender
        public string ProfilePickUrl { get; set; }
        public User User { get; set; }
    }
}
