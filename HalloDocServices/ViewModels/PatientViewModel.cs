using HalloDocRepository.DataModels;

namespace HalloDocServices.ViewModels
{
    public class ViewModel
    {

        public List<Request> Requests { get; set; }


        public List<RequestWiseFile> RequestWiseFile { get; set; }

        public List<PatientProfile> PatientProfiles { get; set; }



    }
}
