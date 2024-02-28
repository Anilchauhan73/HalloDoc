using HalloDocRepository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDocServices.Admin
{
    public class DashboardDetails
    {
        public int? bgcolor { get; set; }

        public int? newRequest { get; set; }

        public int? pendingRequest { get; set; }

        public int? activeRequest { get; set; }

        public List<RequestClient>? clients { get; set; }

    }
}
