using HalloDocRepository.DataModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace HalloDocServices.ViewModels
{
    public class PatientDashboard
    {


        public List<Request> Request { get; set; }

        public List<RequestWiseFile> RequestWiseFile { get; set; }






    }

}
