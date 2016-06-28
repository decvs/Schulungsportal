using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schulungsportal.Data
{
    public class Email
    {
        public Email()
        {

        }
        public Email(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }
        public override string ToString()
        {
            return this.Value;
        }
    }
}