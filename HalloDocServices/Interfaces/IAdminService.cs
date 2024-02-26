using HalloDocRepository.DataModels;
using HalloDocServices.Admin;
using HalloDocServices.ViewModels;

namespace HalloDocServices.Interfaces
{
    public interface IAdminService
    {
        List<RequestClient> newDashboard();
        List<RequestClient> pendingDashboard();
        ViewCase ViewCase(int reqid);
    }
}