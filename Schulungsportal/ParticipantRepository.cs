using Schulungsportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schulungsportal
{
    public class ParticipantRepository
    {
        
        public IQueryable<Participant> Query 
        {
            get 
            {
                return new List<Participant>()
                {
                    new Participant{ Id = 1, Firstname="Christian", Lastname="von Seydlitz", Email="cvs@von-seydlitz.de", Website="www.von-seydlitz.de", Company= "private"},
                    new Participant{ Id = 2, Firstname="Irina", Lastname="von Seydlitz", Email="irina@von-seydlitz.de", Website="www.von-seydlitz.de", Company= "private"},
                    new Participant{ Id = 3, Firstname="Simon", Lastname="von Seydlitz", Email="simon@von-seydlitz.de", Website="www.von-seydlitz.de", Company= "private"},
                    new Participant{ Id = 4, Firstname="Luca", Lastname="von Seydlitz", Email="luca@von-seydlitz.de", Website="www.von-seydlitz.de", Company= "private"}
                }.AsQueryable<Participant>();
            }
        }
    }
}