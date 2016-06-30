using Schulungsportal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schulungsportal.Models
{
    public class Post : IIdentifyableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }
    }
}
