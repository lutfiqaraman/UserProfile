namespace UserProfileAPIDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfile", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfile", "Password");
        }
    }
}
