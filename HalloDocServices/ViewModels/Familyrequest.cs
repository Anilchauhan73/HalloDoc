using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HalloDocServices.ViewModels
{
    public class Familyrequest
    {


        [Required(ErrorMessage = "FirstName is required")]
        public string YourFirstName { get; set; } = null!;
        [Required(ErrorMessage = "LastName is required")]
        public required string YourLastName { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public required string YourPhoneNumber { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string YourEmail { get; set; } = null!;



        public required string Symptoms { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public required DateTime BirthDate { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        public required string RelationWithPatient { get; set; }

        public required string Street { get; set; }

        public required string City { get; set; }

        public required string State { get; set; }

        public required string ZipCode { get; set; }

        public required string Room { get; set; }


        public IEnumerable<IFormFile> File { get; set; }


    }
}
