using Schulungsportal.Data.Mappings;
using Schulungsportal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schulungsportal.Data
{
    public class TpContext : DbContext
    {
        public TpContext()
            : base("name=tpContext")
        {
            Database.SetInitializer(new TpDatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ParticipantMappings());
        }
        public DbSet<Participant> Participants { get; set; }


        
    }

    public class TpDatabaseInitializer : DropCreateDatabaseAlways<TpContext>
    {
        protected override void Seed(TpContext context)
        {
            base.Seed(context);
            context.Participants.Add(new Participant { Firstname = "Christian", Lastname = "von Seydlitz", Email = "cvs@von-seydlitz.de", Website = "www.von-seydlitz.de", Company = "private" });
            context.Participants.Add(new Participant { Firstname = "Irina", Lastname = "von Seydlitz", Email = "cvs@von-seydlitz.de", Website = "www.von-seydlitz.de", Company = "private" });
            context.Participants.Add(new Participant { Firstname = "Simon", Lastname = "von Seydlitz", Email = "cvs@von-seydlitz.de", Website = "www.von-seydlitz.de", Company = "private" });
            context.Participants.Add(new Participant { Firstname = "Luca", Lastname = "von Seydlitz", Email = "cvs@von-seydlitz.de", Website = "www.von-seydlitz.de", Company = "private" });
        }
    }
}