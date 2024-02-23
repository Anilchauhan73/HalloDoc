using HalloDocRepository.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDocRepository.Interfaces
{
    public interface IPatientloginRepository
    {
        List<AspNetUser> GetAllUsers();
        bool Patient_login(string username, string password);
    }
}
