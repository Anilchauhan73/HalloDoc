using System.ComponentModel.DataAnnotations;

namespace HalloDocServices.ViewModels
{
    public class Conceirgerequest1
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string YourFirstName { get; set; } = null!;
        [Required(ErrorMessage = "LastName is required")]
        public required string YourLastName { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public required string YourPhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public required string YourEmail { get; set; }

        [Required(ErrorMessage = "PropertyName is required")]
        public required string PropertyName { get; set; }

        public required string YourStreet { get; set; }

        public required string YourCity { get; set; }

        public required string YourState { get; set; }

        public required string YourZipCode { get; set; }

        public required string Symptoms { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string BirthDate { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        public required string Room { get; set; }


    }
}
