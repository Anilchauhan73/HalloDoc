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
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
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
                UserId=user.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                CreatedDate = DateTime.Now,
                RequestTypeId = 1,
                Status = 1,
                IsUrgentEmailSent = '1',
                User = user,
            };

            _context.Requests.Add(request);
            _context.SaveChanges();

            RequestClient requestClient = new RequestClient
            {
                RequestId = request.RequestId,
                Notes = model.Symptoms,
                FirstName= model.FirstName,
                LastName= model.LastName,
                PhoneNumber= model.PhoneNumber,
                Email= model.Email,
                Street= model.Street,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                IntDate = model.BirthDate.Day,
                IntYear = model.BirthDate.Year,
                StrMonth = (model.BirthDate.Month).ToString(),
                Request = request,
                
            };
            _context.RequestClients.Add(requestClient);
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
            _context.SaveChanges();

            Request request = new Request
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                CreatedDate = DateTime.Now,
                RequestTypeId = 2,
                Status = 1,
                IsUrgentEmailSent = '1',
                User = user,
            };

            _context.Requests.Add(request);
            _context.SaveChanges();



            RequestClient requestfamily = new RequestClient
            {

                RequestClientId = request.RequestId,
                FirstName = model.YourFirstName,
                LastName = model.YourLastName,
                PhoneNumber = model.YourPhoneNumber,
                Email = model.YourEmail,
                State = model.RelationWithPatient,
                Request = request,

            };

            _context.RequestClients.Add(requestfamily);
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
            _context.SaveChanges();

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
            _context.SaveChanges();




            Request request = new Request
            {

                FirstName = model.YourFirstName,
                LastName = model.YourLastName,
                PhoneNumber = model.YourPhoneNumber,
                Email = model.YourEmail,
                CreatedDate = DateTime.Now,
                Status = 1,
                IsUrgentEmailSent = '1',
                User = user,
            };


            _context.Requests.Add(request);
            _context.SaveChanges();


            RequestClient requestconceirge = new RequestClient
            {
                FirstName = model.YourFirstName,
                LastName = model.YourLastName,
                PhoneNumber = model.YourPhoneNumber,
                Email = model.YourEmail,


            };

            _context.RequestClients.Add(requestconceirge);
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
       



        public User ProfileService(string Email)
        {
            User data = _context.Users.Where(x => x.Email == Email).FirstOrDefault();
           
            return data;

        }

        public void PaProfile(string email, User model)
        {
            var userdata = _context.Users.Where(x => x.Email == email).FirstOrDefault();

            if (userdata.Email == model.Email)
            {

                userdata.FirstName = model.FirstName;
                userdata.LastName = model.LastName;
                userdata.Mobile = model.Mobile;
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
                    PhoneNumber = model.Mobile,
                    ModifiedDate = DateTime.Now,

                };

                _context.AspNetUsers.Add(aspnetuser);
            }

        }


        private const int TokenExpirationMinutes = 15;

        //public string GenerateToken()
        //{
        //    byte[] tokenBytes = new byte[32];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(tokenBytes);
        //    }

        //    string token = Convert.ToBase64String(tokenBytes);

        //    return token;
        //}
        //public void SendMail(SendMail details, string resetLink)
        //{
        //    var subject = "Password Reset Request";
        //    var body = "<b>Please find the Password Reset Link.</b><br/>" + resetLink;

        //    MailMessage mail = new();
        //    mail.To.Add(details.Email!);
        //    mail.From = new MailAddress("temp2713@outlook.com");
        //    mail.Subject = subject;
        //    mail.Body = body;
        //    mail.IsBodyHtml = true;
        //    var smtpClient = new SmtpClient
        //    {
        //        Host = "smtp.office365.com",
        //        Port = 587,
        //        UseDefaultCredentials = false,
        //        EnableSsl = true,
        //        Credentials = new NetworkCredential("temp2713@outlook.com", "Anil"),
        //        DeliveryMethod = SmtpDeliveryMethod.Network
        //    };
        //    smtpClient.Send(mail);
        //}
    }
}
