﻿using Schulungsportal.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security;
using System.Web;

namespace Schulungsportal.Models
{
    public class Participant : IIdentifyableEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Bitte einen gültigen Vorname eingeben")]
        [MinLength(2, ErrorMessage="Bitte 2 Zeichen eingeben")]
        public string Firstname { get; set; }

        [Required(ErrorMessage="Bitte einen Nachname eingeben")]
        [MinLength(3, ErrorMessage="Bitte 3 Zeichen eingeben")]
        public string Lastname { get; set; }
        public string Email{ get; set; }
        public string Website { get; set; }
        public string Company { get; set; }
        public byte[] ProfilePicture { get; set; }

        public string ProfilePictureContentType { get; set; }
                
        public string Password { get; set; }

        
    }
}