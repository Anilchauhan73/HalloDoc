using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDocServices.ViewModels
{
    public class Patienlogin
    {
        public required string Email { get; set; }

        public required string Passwordhash { get; set; }
    }
}
