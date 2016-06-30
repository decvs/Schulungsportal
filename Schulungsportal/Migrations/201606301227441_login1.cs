namespace Schulungsportal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class login1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participants", "Password");
        }
    }
}
