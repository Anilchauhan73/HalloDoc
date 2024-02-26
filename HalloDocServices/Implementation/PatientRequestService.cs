using HalloDocRepository.DataContext;
using HalloDocRepository.DataModels;
using HalloDocServices.Admin;
using HalloDocServices.Interfaces;
using HalloDocServices.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Primitives;
using System.IO.Compression;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    string uploadFolder = path + "\\wwwroot\\Uploads";

                    string uniqueFilename = Guid.NewGuid().ToString() + "_" + Filename;
                    string FilePath = Path.Combine(uploadFolder, uniqueFilename);
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
                    string uploadFolder = path + "\\wwwroot\\Uploads";

                    string uniqueFilename = Guid.NewGuid().ToString() + "_" + Filename;
                    string FilePath = Path.Combine(uploadFolder, uniqueFilename);
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
       

        //public PatientProfile ProfileData( PatientProfile profile , string Email)
        //{
        //    var user = _context.RequestClients.Where(u => u.Email == Email).FirstOrDefault();
            
        //    //DateTime dob = DateTime.ParseExact(user.IntYear.ToString() + "-" + user.StrMonth + "-" + user.IntDate.ToString(), "yyyy-M-d", System.Globalization.CultureInfo.InvariantCulture);

        //    PatientProfile profile1 = new PatientProfile()
        //    {
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        //BirthDate = dob.ToString("yyyy-MM-dd"),
        //        Email = user.Email,
        //        PhoneNumber = user.PhoneNumber,
        //        Street = user.Street,
        //        State = user.State,
        //        City = user.City,
        //        ZipCode = user.ZipCode,


        //    };
        //    return profile1;

        //}

        //public void PatientProfile1(PatientProfile profile, string Email)
        //{
        //    var data = _context.Users.Where(a => a.Email == Email).FirstOrDefault();

        //    if (data.Email == profile.Email)
        //    {
        //        data.FirstName = profile.FirstName;
        //        data.LastName = profile.LastName;
        //        data.Email = profile.Email;
        //        data.Mobile = profile.PhoneNumber;
        //        data.Street = profile.Street;
        //        data.City = profile.City;
        //        data.State = profile.State;
        //        data.ZipCode = profile.ZipCode;
        //        data.ModifiedDate = DateTime.Now;

        //        _context.Users.Add(data);
        //        _context.SaveChanges();
        //    }
        //    else
        //    {
        //        AspNetUser aspnetuser = new AspNetUser()
        //        {
        //            UserName = profile.FirstName + " " + profile.LastName,
        //            Email = profile.Email,
        //            PhoneNumber = profile.PhoneNumber,
        //            ModifiedDate = DateTime.Now,
        //        };
        //        _context.AspNetUsers.Add(aspnetuser);
        //    }
        //}

        public User ProfileService(string Email)
        {
            User data = _context.Users.Where(x => x.Email == Email).FirstOrDefault();
            return data;

        }

        public void PaProfile(string email, PatientProfile model)
        {
            var userdata = _context.Users.Where(x => x.Email == email).FirstOrDefault();

            if (userdata.Email == model.Email)
            {

                userdata.FirstName = model.FirstName;
                userdata.LastName = model.LastName;
                userdata.Mobile = model.PhoneNumber;
                userdata.Email = model.Email;
                userdata.Street = model.Street;
                userdata.City = model.City;
                userdata.State = model.State;
                userdata.ZipCode = model.ZipCode;
                userdata.ModifiedDate = DateTime.Now;

                _context.Users.Update(userdata);

                _context.SaveChanges();
            }
            else
            {
                AspNetUser aspnetuser = new AspNetUser()
                {
                    UserName = model.FirstName + " " + model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    ModifiedDate = DateTime.Now,

                };

                _context.AspNetUsers.Add(aspnetuser);
            }



        }


    }
}
