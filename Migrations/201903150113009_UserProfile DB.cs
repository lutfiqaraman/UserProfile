namespace UserProfileAPIDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfileDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateofBirth = c.DateTime(nullable: false),
                        Country = c.String(),
                        Address = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Salary = c.Double(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfile");
        }
    }
}
