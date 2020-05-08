using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Resources
{
  public class SaveUserResource
    {   [Required]
        [MaxLength(50)]
        public string Email_address { get; set; }
        [Required]
        [MaxLength(15)]
        public string Username { get; set; }
        [Required]
        [MaxLength(15)]
        public string Password { get; set; }
    }
}
