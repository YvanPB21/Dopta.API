using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Resources
{
    public class SavePetResource
    {
        [Required]//data annotation
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public int SpecieId { get; set; }
        [Required]
        public int Sex { get; set; }
        [Required]
        public int Size { get; set; }


    }
}
