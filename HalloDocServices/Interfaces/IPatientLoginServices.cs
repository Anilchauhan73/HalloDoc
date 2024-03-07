using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalloDocRepository.DataModels;
using HalloDocServices.ViewModels;

namespace HalloDocServices.Interfaces
{
    public interface IPatientLoginServices
    {
        Task<User> Patient_login(AspNetUser model);
    }
}



