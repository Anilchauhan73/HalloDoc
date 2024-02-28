using HalloDocRepository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDocServices.Admin
{
    public class ViewNotes
    {
        public string TransferNotes { get; set; }

        public string PhysicianNotes { get; set;}

        public string AdminNotes { get; set; }

        public List<RequestNote> notes { get; set; }
    }
}
