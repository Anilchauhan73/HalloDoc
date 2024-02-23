using HalloDocServices.Interfaces;
using HalloDocRepository.DataModels;
using HalloDocServices.ViewModels;
using HalloDocRepository.Interfaces;
using Microsoft.AspNetCore.Http;


namespace HalloDocServices.Implementation
{
    public class PatientLoginServices : IPatientLoginServices

    {


        private IPatientloginRepository _PatientLoginRepository;
        private readonly IPatientLoginServices patientLoginServices;

        public PatientLoginServices(IPatientloginRepository PatientLoginRepository)
        {
            _PatientLoginRepository = PatientLoginRepository;
        }

        
        public bool Patient_login(Patienlogin ViewModel)
        {
            //Any business logic here before repository call
            //Convert view model => DataModel Here
            bool isValidUser = _PatientLoginRepository.Patient_login(ViewModel.Email, ViewModel.Passwordhash);

            var users = _PatientLoginRepository.GetAllUsers();
      

            //var emailList = users.Select(x => x.Email);
            return isValidUser;
        }
          

      
    }    
}
