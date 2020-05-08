using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Resources
{
    public class SavePostResource
    {
        [Required]//data annotation
        [MaxLength(30)]
        public string Description { get; set; }
    }
}
