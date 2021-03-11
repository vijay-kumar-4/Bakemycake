namespace Auth_Forms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel0001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ImagePath = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        PersonalAddress = c.String(),
                        Password = c.String(),
                        WorkAddress = c.String(),
                        PhoneNumber = c.Long(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Items");
        }
    }
}
