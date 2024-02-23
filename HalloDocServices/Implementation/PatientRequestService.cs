using HalloDocRepository.DataContext;
using HalloDocRepository.DataModels;
using HalloDocServices.Interfaces;
using HalloDocServices.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System.IO.Compression;
using System.Text;

namespace HalloDocServices.Implementation
{
    public class PatientRequestService : IPatientRequestService
    {

        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
  
        public dynamic ViewBag { get; set; }
     

        public PatientRequestService(ApplicationDbContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
           
        }

        [HttpPost]
        public void CreatePatientRequest(Patientrequest model)
        {

            AspNetUser aspnetuser = _context.AspNetUsers.FirstOrDefault(u => u.Email == model.Email);


            if (aspnetuser == null)
            {
                AspNetUser aspnetuser1 = new AspNetUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.FirstName + "_" + model.LastName,
                    Email = model.Email,

                    PhoneNumber = model.PhoneNumber,
                    CreatedDate = DateTime.Now,
                };
                _context.AspNetUsers.Add(aspnetuser1);

                _context.SaveChanges();
            }


            User user = new User
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Mobile = model.PhoneNumber,
                ZipCode = model.ZipCode,
                State = model.State,
                City = model.City,
                Street = model.Street,
                IntDate = model.BirthDate.Day,
                IntYear = model.BirthDate.Year,
                StrMonth = (model.BirthDate.Month).ToString(),
                CreatedDate = DateTime.Now,
                CreatedBy = "Patient",
                AspNetUser = aspnetuser,
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            Request request = new Request
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                CreatedDate = DateTime.Now,
                Status = 1,
                IsUrgentEmailSent = '1',
                User = user,
            };

            _context.Requests.Add(request);


            _context.SaveChanges();

            foreach (var item in model.File)
            {
                var Filename = item.FileName;
                //String uniqueFilename = null;
                if (model.File != null)
                {
                    string path = Directory.GetCurrentDirectory();
                    //String uploadFolder = Path.Combine(path,"\\wwwroot\\Uploads");
                    String uploadFolder = path + "\\wwwroot\\Uploads";

                    String uniqueFilename = Guid.NewGuid().ToString() + "_" + Filename;
                    String FilePath = Path.Combine(uploadFolder, uniqueFilename);
                    item.CopyTo(target: new FileStream(FilePath, FileMode.Create));


                    RequestWiseFile requestWiseFile = new RequestWiseFile
                    {
                        RequestId = request.RequestId,
                        FileName = uniqueFilename,
                        Request = request,
                        CreatedDate = DateTime.Now
                    };
                    _context.RequestWiseFiles.Add(requestWiseFile);
                    _context.SaveChanges();

                }

            }

        }


        [HttpPost]
        public void CreateFamilyRequest(Familyrequest model)
        {

            AspNetUser aspnetuser = _context.AspNetUsers.FirstOrDefault(u => u.Email == model.Email);


            if (aspnetuser == null)
            {
                AspNetUser aspnetuser1 = new AspNetUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.FirstName + "_" + model.LastName,
                    Email = model.Email,
                    PasswordHash = model.FirstName,
                    PhoneNumber = model.PhoneNumber,
                    CreatedDate = DateTime.Now,
                };
                _context.AspNetUsers.Add(aspnetuser1);
                aspnetuser = aspnetuser1;
            }


            User user = new User
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Mobile = model.PhoneNumber,
                ZipCode = model.ZipCode,
                State = model.State,
                City = model.City,
                Street = model.Street,
                IntDate = model.BirthDate.Day,
                IntYear = model.BirthDate.Year,
                StrMonth = (model.BirthDate.Month).ToString(),
                CreatedDate = DateTime.Now,
                CreatedBy = "Family",
                AspNetUser = aspnetuser,
            };

            _context.Users.Add(user);

            RequestClient requestfamily = new RequestClient
            {

                RequestId = 54645,
                FirstName = model.YourFirstName,
                LastName = model.YourLastName,
                PhoneNumber = model.YourPhoneNumber,
                Email = model.YourEmail,
                State = model.RelationWithPatient,

            };

            _context.RequestClients.Add(requestfamily);

            Request request = new Request
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                CreatedDate = DateTime.Now,
                Status = 1,
                IsUrgentEmailSent = '1',
                User = user,
            };

            _context.Requests.Add(request);
            _context.SaveChanges();


            foreach (var item in model.File)
            {
                var Filename = item.FileName;
                //String uniqueFilename = null;
                if (model.File != null)
                {
                    string path = Directory.GetCurrentDirectory();
                    //String uploadFolder = Path.Combine(path,"\\wwwroot\\Uploads");
                    String uploadFolder = path + "\\wwwroot\\Uploads";

                    String uniqueFilename = Guid.NewGuid().ToString() + "_" + Filename;
                    String FilePath = Path.Combine(uploadFolder, uniqueFilename);
                    item.CopyTo(target: new FileStream(FilePath, FileMode.Create));


                    RequestWiseFile requestWiseFile = new RequestWiseFile
                    {
                        RequestId = request.RequestId,
                        FileName = uniqueFilename,
                        Request = request,
                        CreatedDate = DateTime.Now
                    };
                    _context.RequestWiseFiles.Add(requestWiseFile);
                    _context.SaveChanges();

                }

            }


        }



        [HttpPost]
        public void CreateConceirgeRequest(Conceirgerequest1 model)
        {

            AspNetUser aspnetuser = _context.AspNetUsers.FirstOrDefault(u => u.Email == model.Email);



            User user = new User
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Mobile = model.PhoneNumber,
                CreatedDate = DateTime.Now,
                CreatedBy = "Conceirge",

            };

            _context.Users.Add(user);

            Concierge concierge = new Concierge
            {
                ConciergeName = model.YourFirstName,
                Street = model.YourStreet,
                City = model.YourCity,
                State = model.YourState,
                ZipCode = model.YourZipCode,
                CreatedDate = DateTime.Now,
            };

            _context.Concierges.Add(concierge);

            RequestClient requestconceirge = new RequestClient
            {
                FirstName = model.YourFirstName,
                LastName = model.YourLastName,
                PhoneNumber = model.YourPhoneNumber,
                Email = model.YourEmail,

            };

            _context.RequestClients.Add(requestconceirge);

            Request request = new Request
            {

                FirstName = model.YourFirstName,
                LastName = model.YourLastName,
                PhoneNumber = model.YourPhoneNumber,
                Email = model.YourEmail,
                CreatedDate = DateTime.Now,
                Status = 2,
                IsUrgentEmailSent = '1',
                User = user,
            };

            _context.Requests.Add(request);
            _context.SaveChanges();

        }


        public PatientDashboard PatientDashboard(PatientDashboard dashboard, string email)
        {
            List<Request> userData = _context.Requests.Where(u => u.Email == email).ToList();
            PatientDashboard dashboard1 = new PatientDashboard();
            dashboard1.Request = userData;

            List<RequestWiseFile> userData2 = _context.RequestWiseFiles.ToList();
            dashboard1.RequestWiseFile = userData2;
          
            return dashboard1;
        }

    
        public ViewDocument ViewDocument(int id)
        {
            Request data = _context.Requests.Where(x => x.RequestId == id).FirstOrDefault();
            RequestClient requestClient = _context.RequestClients.Where(x => x.RequestId == id).FirstOrDefault()!;
            List<RequestWiseFile> requestWiseFile = _context.RequestWiseFiles.Where(x => x.RequestId == id).ToList();

            ViewDocument Viewdoc = new ViewDocument()
            {
                Requests = data,
                RequestWiseFiles = requestWiseFile,
                RequestClients = requestClient

            };
            return Viewdoc;

        }

        public async Task<byte[]> DownLoadAll(int requestid)
        {

            var zipName = $"RequestFiles-{requestid}-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

            using (MemoryStream ms = new MemoryStream())
            {
                using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
                {
                    var filesForRequest = await _context.RequestWiseFiles
                        .Where(file => file.RequestId == requestid)
                        .ToListAsync();
                    var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
                    foreach (var file in filesForRequest)
                    {
                        var filepath = Path.Combine(uploads, file.FileName);

                        if (!string.IsNullOrEmpty(filepath) && System.IO.File.Exists(filepath))
                        {
                            var entry = zip.CreateEntry(Path.GetFileName(filepath));

                            using (var entryStream = entry.Open())
                            using (var fileStream = System.IO.File.OpenRead(filepath))
                            {
                                await fileStream.CopyToAsync(entryStream);
                            }
                        }
                    }
                }
                return (ms.ToArray());
            }

        }
    }
}
