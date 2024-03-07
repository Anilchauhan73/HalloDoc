
using HalloDocRepository.DataContext;
using HalloDocRepository.DataModels;
using HalloDocServices.Implementation;
using HalloDocServices.Interfaces;
using HalloDocServices.ViewModels;
using HalloDocWebDemo.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HalloDocWebDemo.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IPatientLoginServices _PatientLoginServices;
        private readonly IJwtService _jwtService;
        private readonly ApplicationDbContext _context;
        public HomeController(IPatientLoginServices PatientLoginServices , IJwtService jwtService , ApplicationDbContext context)
        {
            _PatientLoginServices = PatientLoginServices;
            _jwtService = jwtService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Patient_login()
        {
            return View();
        }


        public IActionResult Forget_pass()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Patient_login(AspNetUser model)
        {

            HttpContext.Session.SetString("userEmail", model.Email);

            var userId = await _PatientLoginServices.Patient_login(model);

            var aspnetuser = _context.AspNetUsers.FirstOrDefault(u => u.Email == model.Email);
            if (userId == null)
            {
                TempData["error"] = "Username or Password is Incorrect";
                return View("Login");
            }
            else
            {
                TempData["success"] = "User LogIn Successfully";
                HttpContext.Session.SetString("userId", userId.ToString());


                var jwtToken = _jwtService.GenerateJwtToken(aspnetuser);

                Response.Cookies.Append("jwt", jwtToken);

                return RedirectToAction("PatientDashboard", "Patient");

            }
        }

     

        public IActionResult Patient_register()
        {
            return View();
        }

    
        public IActionResult Business_request()
        {
            return View();
        }
  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new HalloDocServices.ViewModels.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}