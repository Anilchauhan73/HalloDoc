using HalloDocRepository.DataContext;
using HalloDocServices.Admin;
using HalloDocServices.Implementation;
using HalloDocServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HalloDocWebDemo.Controllers
{
    public class AdminController : Controller
    {

    

        private readonly IAdminService _AdminService;
        private readonly ApplicationDbContext _context;
   
        public AdminController(IAdminService AdminService, ApplicationDbContext context )
        {
            _AdminService = AdminService;
            _context = context;
           
        }

        public IActionResult AdminDashboard()
        {
            DashboardDetails details = new DashboardDetails();
            details.newRequest = _AdminService.newDashboard().Count;
            details.pendingRequest = _AdminService.pendingDashboard().Count;
            return View(details);


        }

        public IActionResult NewTable()
        {
            DashboardDetails details = new();
            details.clients = _AdminService.newDashboard();
            return PartialView(details);
        }

        

        public IActionResult PendingTable()
        {
            DashboardDetails details = new();
            details.clients = _AdminService.pendingDashboard();
            
            return PartialView(details);
        }

        public IActionResult ActiveTable()
        {
            DashboardDetails details2 = new();
            details2.clients = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 3).ToList();
            return PartialView(details2);
        }

        public IActionResult ConcludeTable()
        {
            DashboardDetails details3 = new();
            details3.clients = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 4).ToList();
            return PartialView(details3);
        }

        public IActionResult ToCloseTable()
        {
            DashboardDetails details4 = new();
            details4.clients = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 5).ToList();
            return PartialView(details4);
        }


        public IActionResult UnpaidTable()
        {
            DashboardDetails details5 = new();
            details5.clients = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 6).ToList();
            return PartialView(details5);
        }
        public IActionResult ViewCase(int reqid)
        {

            var data = _AdminService.ViewCase(reqid);
            return View(data);
        }




    }
}



