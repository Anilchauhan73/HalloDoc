using HalloDocServices.Interfaces;
using HalloDocRepository.DataModels;
using HalloDocServices.ViewModels;
using HalloDocRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using HalloDocRepository.DataContext;

namespace HalloDocServices.Implementation
{
    public class PatientLoginServices : IPatientLoginServices

    {


        private IPatientloginRepository _PatientLoginRepository;
        private readonly IPatientLoginServices patientLoginServices;
        private readonly ApplicationDbContext _context;

        public PatientLoginServices(IPatientloginRepository PatientLoginRepository , ApplicationDbContext context)
        {
            _PatientLoginRepository = PatientLoginRepository;
            _context = context;
        }


        public async Task<User> Patient_login(AspNetUser model)
        {
            var aspnetuser = await _context.AspNetUsers.FirstOrDefaultAsync(u => u.Email == model.Email && u.PasswordHash == model.PasswordHash);

            if (aspnetuser != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                return user!;
            }
            else
            {
                return null!;
            }
        }







    }
}
