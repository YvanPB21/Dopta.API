using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Resources
{
    public class SaveSpecieResource
    {
        [Required]//data annotation
        [MaxLength(30)]
        public string Name { get; set; }

    }
}
