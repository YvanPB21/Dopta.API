<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Resources
{
    public class SaveUserProfileResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public int Dni { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //falta gender
        [Required]
        [MaxLength(255)]
        public string ProfilePickUrl { get; set; }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Resources
{
    public class SaveUserProfileResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public int Dni { get; set; }
        //public DateTime DateOfBirth { get; set; }
        //falta gender
        [Required]
        [MaxLength(255)]
        public string ProfilePickUrl { get; set; }
    }
}
>>>>>>> Miguel
