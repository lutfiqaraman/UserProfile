namespace UserProfileAPIDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfile", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.UserProfile", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfile", "Password", c => c.String());
            AlterColumn("dbo.UserProfile", "Name", c => c.String());
        }
    }
}
