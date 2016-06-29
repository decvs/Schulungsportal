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
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TpContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ParticipantMappings());
        }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}