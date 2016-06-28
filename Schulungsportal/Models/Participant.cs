using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schulungsportal.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email{ get; set; }
        public string Website { get; set; }
        public string Company { get; set; }
    }
}