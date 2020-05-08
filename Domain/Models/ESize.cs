using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Dopta.API.Domain.Models
{
    public enum ESize
    {
        [Description("Small")]
        Small = 1,
        [Description("Medium")]
        Medium = 2,
        [Description("Big")]
        Big = 3,
    }
}
