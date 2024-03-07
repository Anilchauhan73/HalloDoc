using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloDocServices.ViewModels
{
    public class SendMail
    {
        public string? Email { get; set; } = null;

        public string? PasswordHash { get; set; }

        [NotMapped]
        [Compare("PasswordHash", ErrorMessage = "Password and Confirm Password Should be match")]
        public string? ConfirmPasswordHash { get; set; }

        public string? Token { get; set; } = null;
    }
}
