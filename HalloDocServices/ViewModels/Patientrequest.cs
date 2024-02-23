using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HalloDocServices.ViewModels
{
    public class Patientrequest
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "LastName is required")]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public required string PhoneNumber { get; set; }

        public required string ZipCode { get; set; }

        public required string State { get; set; }

        public required string City { get; set; }

        public required string Street { get; set; }

        public required string Symptoms { get; set; }

        public required string Room { get; set; }

        public required DateTime BirthDate { get; set; }


        public required string PasswordHash { get; set; }

        public required string confirmPasswordHash { get; set; }

        public  IEnumerable<IFormFile> File { get; set; }










    }
}
