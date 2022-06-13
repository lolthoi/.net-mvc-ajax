namespace Exam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_teacher_table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "Teacher_Name", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Teacher_Email", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Teacher_ContactNo", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Teacher_Department", c => c.String(nullable: false));
            AlterColumn("dbo.Teachers", "Teacher_Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "Teacher_Address", c => c.String());
            AlterColumn("dbo.Teachers", "Teacher_Department", c => c.String());
            AlterColumn("dbo.Teachers", "Teacher_ContactNo", c => c.String());
            AlterColumn("dbo.Teachers", "Teacher_Email", c => c.String());
            AlterColumn("dbo.Teachers", "Teacher_Name", c => c.String());
        }
    }
}
