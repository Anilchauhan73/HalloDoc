using HalloDocRepository.DataModels;
using HalloDocServices.Implementation;
using HalloDocServices.Interfaces;
using HalloDocServices.ViewModels;
using HalloDocWebDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HalloDocWebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPatientLoginServices _PatientLoginServices;
        public HomeController(IPatientLoginServices PatientLoginServices)
        {
            _PatientLoginServices = PatientLoginServices;
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
   

        [HttpPost]
        public IActionResult Patient_login(Patienlogin ViewModel)
        {

            HttpContext.Session.SetString("userEmail" , ViewModel.Email);

            if (!ModelState.IsValid)
            {
              
                return View(ViewModel);
            }

            bool isValidUser = _PatientLoginServices.Patient_login(ViewModel);


            if (!isValidUser)
            {
                TempData["invalid-user"] = true;
                return View(ViewModel);
            }

            return RedirectToAction("PatientDashboard", "Patient");
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
    }
}