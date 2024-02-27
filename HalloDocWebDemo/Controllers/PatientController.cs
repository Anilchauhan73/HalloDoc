using Microsoft.AspNetCore.Mvc;
using HalloDocServices.Interfaces;
using HalloDocServices.ViewModels;
using HalloDocRepository.DataModels;
using HalloDocServices.Implementation;

namespace HalloDocWebDemo.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientLoginServices _PatientLoginService;
        private readonly IPatientRequestService _PatientRequestService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;
        public PatientController(IPatientLoginServices PatientLoginService, IPatientRequestService PatientRequestService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _PatientLoginService = PatientLoginService;
            _PatientRequestService = PatientRequestService;
            this.hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Patient_request()
        {
            return View();
        }


        [HttpPost]

        public IActionResult CreatePatientRequest(Patientrequest patientrequest)
        {
            
                _PatientRequestService.CreatePatientRequest(patientrequest);
                return RedirectToAction("Index", "Home");

        }


        public IActionResult Family_request()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateFamilyRequest(Familyrequest familyrequest)
        {


            _PatientRequestService.CreateFamilyRequest(familyrequest);
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Conceirge_request()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateConceirgeRequest(Conceirgerequest1 conceirgerequest)
        {


            _PatientRequestService.CreateConceirgeRequest(conceirgerequest);
            return RedirectToAction("Index", "Home");

        }




        public IActionResult PatientDashboard(PatientDashboard dashboard,string email)
        {

             
            var email1 = HttpContext.Session.GetString("userEmail");
            if(email1 == null)
            {
                HttpContext.Session.SetString("userEmail", email);
            }
            var userData =  _PatientRequestService.PatientDashboard(dashboard, email1);
              
               
            return View(userData);


        }


        public IActionResult ViewDocument(int id)
        {
            var data = _PatientRequestService.ViewDocument(id);
            return View(data);
        }

        public async Task<IActionResult> DownLoadAll(int requestid)
        {
            var download = await _PatientRequestService.DownLoadAll(requestid);
            return File(download, "application/zip", "RequestFiles.zip");
        }

       
        [HttpGet]
        public IActionResult PatientProfile()
        {
            var email = HttpContext.Session.GetString("userEmail");
            var data = _PatientRequestService.ProfileService(email);
            return View(data);
        }

        public IActionResult PaProfile(User model)
        {
            var email = HttpContext.Session.GetString("userEmail");
            _PatientRequestService.PaProfile(email, model);
            return RedirectToAction("PatientProfile", "Patient");
        }

    }
}
