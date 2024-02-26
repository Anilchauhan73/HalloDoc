using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalloDocRepository.DataModels;
using HalloDocServices.Interfaces;
using HalloDocServices.ViewModels;
using HalloDocRepository.DataContext;
using Microsoft.EntityFrameworkCore;
using HalloDocServices.Admin;
using System.IO;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace HalloDocServices.Implementation
{
    public class AdminService : IAdminService
    {

        private readonly ApplicationDbContext _context;
        public AdminService(ApplicationDbContext context)
        {
            _context = context;
           

        }

        public List<RequestClient> newDashboard()
        {
            List<RequestClient> newRequest = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 1).ToList();
            return newRequest;
        }

        public List<RequestClient> pendingDashboard()
        {
            List<RequestClient> pendingRequest = _context.RequestClients.Include(u => u.Request).Where(u => u.Request.Status == 2).Include(u => u.Request.Physician).ToList();
            return pendingRequest;
        }

        public ViewCase ViewCase(int reqid)
        {

            var user = _context.RequestClients.FirstOrDefault(u => u.RequestClientId == reqid);
            DateTime dob = DateTime.ParseExact(user.IntYear.ToString() + "-" + user.StrMonth + "-" + user.IntDate.ToString(), "yyyy-M-d", System.Globalization.CultureInfo.InvariantCulture);
            ViewCase viewcase = new ViewCase()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = dob.ToString("yyyy-MM-dd"),
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,


            };
            return viewcase;
     
        }
    }
}







