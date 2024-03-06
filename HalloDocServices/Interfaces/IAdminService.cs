using HalloDocRepository.DataModels;
using HalloDocServices.Admin;
using HalloDocServices.ViewModels;

namespace HalloDocServices.Interfaces
{
    public interface IAdminService
    {
        void Addnote(ViewNotes model);
        void AssignCaseRequest(DashboardDetails details, int assignid);
        DashboardDetails AssignCase(int id);
        void CancelPatientRequest(DashboardDetails details, int cancelid);
        List<RequestClient> newDashboard();
        List<RequestClient> pendingDashboard();
        List<RequestClient> ToCloseDashboard();
        ViewCase ViewCase(int reqid);
        ViewNotes ViewNotes();
    }
}