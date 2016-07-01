using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Web;

namespace Schulungsportal.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Username muss angegeben werden")]
        [StringLength(16, ErrorMessage = "Muss zwischen 3 und 16 Zeichen sein", MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vorname muss angegeben werden")]
        [StringLength(16, ErrorMessage = "Muss zwischen 3 und 16 Zeichen sein", MinimumLength = 3)]
        public string Firstname { get; set; }

        public string Company { get; set; }

        public string Website { get; set; }






        [Required(ErrorMessage = "Email muss angegeben werden")]
        [StringLength(16, ErrorMessage = "Muss zwischen 3 und 50 Zeichen sein", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Passwort muss angegeben werden")]
        [StringLength(255, ErrorMessage = "Muss zwischen 3 und 255 Zeichen sein", MinimumLength = 3)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Passwortbestätigung muss angegeben werden")]
        [StringLength(255, ErrorMessage = "Muss zwischen 3 und 255 Zeichen sein", MinimumLength = 3)]

        public string ConfirmPassword { get; set; }
    }
}