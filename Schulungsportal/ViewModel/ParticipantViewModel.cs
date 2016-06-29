using Schulungsportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schulungsportal.ViewModel
{
    public class ParticipantViewModel
    {
        public ParticipantViewModel()
        {
            Participants = new List<Participant>();
        }
        public List<Participant> Participants { get; set; }


        public PaginationViewModel Pagination { get; set; }

    }
}