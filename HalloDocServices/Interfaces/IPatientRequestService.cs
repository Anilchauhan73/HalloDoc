using HalloDocRepository.DataModels;
using HalloDocServices.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HalloDocServices.Interfaces
{
    public interface IPatientRequestService
    {
        void CreateConceirgeRequest(Conceirgerequest1 model);
        void CreateFamilyRequest(Familyrequest model);
        void CreatePatientRequest(Patientrequest patientRequest);
        Task<byte[]> DownLoadAll(int requestid);
     
        PatientDashboard PatientDashboard(PatientDashboard dashboard , string email);

        ViewDocument ViewDocument(int id);


    }
}