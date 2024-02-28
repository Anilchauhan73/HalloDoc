using HalloDocRepository.DataModels;
using HalloDocServices.Admin;
using HalloDocServices.ViewModels;

namespace HalloDocServices.Interfaces
{
    public interface IAdminService
    {
        void Addnote(ViewNotes model);
        List<RequestClient> newDashboard();
        List<RequestClient> pendingDashboard();
        ViewCase ViewCase(int reqid);
        ViewNotes ViewNotes();
    }
}