using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Size> Sizes { get; set; } = new List<Size>();
    }
}
