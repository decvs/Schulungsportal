using Schulungsportal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Schulungsportal.Data.Mappings
{
    public class ParticipantMappings : EntityTypeConfiguration<Participant>
    {
        public ParticipantMappings()
        {
            HasKey(p => p.Id)
            .ToTable("Participants");

            Property(p => p.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Firstname).HasMaxLength(255).HasColumnName("Firstname").HasColumnOrder(1);
        }
    }
}