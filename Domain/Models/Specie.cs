using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Models
{
    public class Specie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Pet> Pets { get; set; } = new List<Pet>();
    }
}
