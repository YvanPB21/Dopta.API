using Dopta.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Resources
{
    public class PetResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecieId { get; set; }
        public SpecieResource Specie { get; set; }
        public string Sex { get; set; }
        public string Size { get; set; }
      
    }
}
