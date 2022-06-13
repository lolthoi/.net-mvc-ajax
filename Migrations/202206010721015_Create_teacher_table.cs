namespace Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_teacher_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Teacher_Name = c.String(),
                        Teacher_Email = c.String(),
                        Teacher_ContactNo = c.String(),
                        Teacher_Department = c.String(),
                        Teacher_Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
        }
    }
}
