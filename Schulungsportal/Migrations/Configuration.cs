namespace Schulungsportal.Migrations
{
    using Schulungsportal.Data;
    using Schulungsportal.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Schulungsportal.Data.TpContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Schulungsportal.Data.TpContext";
        }

        protected override void Seed(Schulungsportal.Data.TpContext context)
        {
            context.Participants.AddOrUpdate(new Participant { Firstname = "Christian", Lastname = "von Seydlitz", Email = "cvs@von-seydlitz.de", Website = "www.von-seydlitz.de", Company = "private" });
            context.Participants.AddOrUpdate(new Participant { Firstname = "Irina", Lastname = "von Seydlitz", Email = "cvs@von-seydlitz.de", Website = "www.von-seydlitz.de", Company = "private" });
            context.Participants.AddOrUpdate(new Participant { Firstname = "Simon", Lastname = "von Seydlitz", Email = "cvs@von-seydlitz.de", Website = "www.von-seydlitz.de", Company = "private" });
            context.Participants.AddOrUpdate(new Participant { Firstname = "Luca", Lastname = "von Seydlitz", Email = "cvs@von-seydlitz.de", Website = "www.von-seydlitz.de", Company = "private" });

            context.Posts.AddOrUpdate(new Post { Title="Heise", Uri="http://www.heise.de" });
            context.Posts.AddOrUpdate(new Post { Title = "Sport1", Uri = "http://www.sport1.de" });
            context.Posts.AddOrUpdate(new Post { Title = "Trump Donald", Uri = "http://trumpdonald.org" });
        }
    }
}
