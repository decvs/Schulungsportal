namespace Schulungsportal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bla2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Participants", "ProfilePictureContentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Participants", "ProfilePictureContentType");
        }
    }
}
