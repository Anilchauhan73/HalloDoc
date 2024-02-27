using HalloDocRepository.DataModels;

namespace HalloDocServices.ViewModels
{
    public class PatientProfile
    {

        public List<User> User { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string PhoneNumber { get; set; }

        public required string Email { get; set; }

        public required string Street { get; set; }

        public required string City { get; set; }

        public required string ZipCode { get; set; }

        public required string State { get; set; }

        public String BirthDate { get; set; }

    }
}
