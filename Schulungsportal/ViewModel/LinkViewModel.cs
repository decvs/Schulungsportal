using Schulungsportal.Data;
using Schulungsportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schulungsportal.ViewModel
{
    public class LinkViewModel
    {
        public LinkViewModel()
        {
            Posts = new List<Post>();
        }
        public List<Post> Posts { get; set; }


        public PaginationViewModel Pagination { get; set; }

    }

}