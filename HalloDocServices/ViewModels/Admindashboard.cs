using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalloDocRepository.DataModels;

namespace HalloDocServices.ViewModels
{
    public class Admindashboard
    {

        public List<Request> Requests { get; set; }

        public List<RequestClient> Clients { get; set; }

    }
}
