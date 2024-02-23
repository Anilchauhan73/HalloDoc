using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HalloDocRepository.DataContext;
using HalloDocRepository.DataModels;
using HalloDocRepository.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace HalloDocRepository.Implementation;

public class PatientLoginRepository : IPatientloginRepository
{
    private readonly ApplicationDbContext _context;
   

    public PatientLoginRepository (ApplicationDbContext context)
    {
        _context = context;
        
    }

   public bool Patient_login(string username, string password)
    {
      
      
        return _context.AspNetUsers.Any(user => user.Email == username && user.PasswordHash == password);
      
    }
  
 
    public List<AspNetUser> GetAllUsers()
    {
        return _context.AspNetUsers.ToList();
         
    }

}
