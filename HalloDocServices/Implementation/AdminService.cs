using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalloDocRepository.DataModels;
using HalloDocServices.Interfaces;
using HalloDocServices.ViewModels;
using HalloDocRepository.DataContext;

namespace HalloDocServices.Implementation
{
    public class AdminService : IAdminService
    {

    //    private readonly ApplicationDbContext _context;
    //    public AdminService(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }
    //    public DashboardDetails RequestedData()
    //    {
    //        List<Request> requests = _context.Requests.Where(u => u.Status == 1).ToList();
    //        List<RequestClient> client = new List<RequestClient>();
    //        foreach (Request request in requests)
    //        {
    //            var user = _context.RequestClients.FirstOrDefault(u => u.RequestId == request.RequestId);
    //            if (user != null)
    //            {
    //                client.Add(user);
    //            }
    //        }

    //        DashboardDetails newRequest = new DashboardDetails();
    //        newRequest.Clients = client;
    //        newRequest.Request = requests;

    //        return newRequest;
    //    }
    }
}







