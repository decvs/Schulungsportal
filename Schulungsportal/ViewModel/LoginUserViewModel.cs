using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;

namespace Schulungsportal.ViewModel
{
    public class LoginUserViewModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}