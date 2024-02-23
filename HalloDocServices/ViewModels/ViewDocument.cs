using HalloDocRepository.DataModels;

namespace HalloDocServices.ViewModels
{
    public class ViewDocument
    {


        public Request Requests { get; set; }

        public List<RequestWiseFile> RequestWiseFiles { get; set; }

        public RequestClient RequestClients { get; set; }

    }
}
