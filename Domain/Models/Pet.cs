using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SpecieId { get; set; }
        public Specie Specie { get; set; }


        public ESex Sex { get; set; }
        public ESize Size { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
