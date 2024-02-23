using HalloDocRepository.DataContext;
using HalloDocServices.Admin;
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

            DashboardDetails dashboarddetails = new();
            int newRequest = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 1).Count();
            dashboarddetails.newRequest = newRequest;
            int pendingRequest = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 2).Count();
            dashboarddetails.pendingRequest = pendingRequest;
            int activeRequest = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 3).Count();
            dashboarddetails.activeRequest = activeRequest;
            return View(dashboarddetails);
        }

        public IActionResult NewTable()
        {
            DashboardDetails details = new();
            details.clients = _context.RequestClients.Include(u => u.Request).Where(u=>u.Request.Status == 1).ToList();
            return PartialView(details);
        }

        public IActionResult PendingTable()
        {
            DashboardDetails details1 = new();
            details1.clients = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 2).Include(u => u.Request.Physician).ToList();
            return PartialView(details1);
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




    }
}



