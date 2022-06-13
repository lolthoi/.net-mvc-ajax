namespace Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(maxLength: 50),
                        dob = c.DateTime(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.Name, t.PhoneNumber }, unique: true, name: "C_Name");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contacts", "C_Name");
            DropTable("dbo.Contacts");
        }
    }
}
