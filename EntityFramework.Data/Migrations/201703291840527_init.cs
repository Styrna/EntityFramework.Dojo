namespace EntityFramework.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        SchoolId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.HeadTeachers",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Name = c.String(),
                        Teacher_Id = c.Long(),
                        Person_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Id)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Person_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Person_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Student_Id = c.Long(nullable: false),
                        Class_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Class_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Class_Id);
            
            CreateTable(
                "dbo.TopicStudents",
                c => new
                    {
                        Topic_Id = c.Long(nullable: false),
                        Student_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Topic_Id, t.Student_Id })
                .ForeignKey("dbo.Topics", t => t.Topic_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Topic_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.SubjectClasses",
                c => new
                    {
                        Subject_Id = c.Long(nullable: false),
                        Class_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Class_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Classes", t => t.Class_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Class_Id);
            
            CreateTable(
                "dbo.TeacherSubjects",
                c => new
                    {
                        Teacher_Id = c.Long(nullable: false),
                        Subject_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_Id, t.Subject_Id })
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.TeacherTopics",
                c => new
                    {
                        Teacher_Id = c.Long(nullable: false),
                        Topic_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_Id, t.Topic_Id })
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.Topic_Id, cascadeDelete: true)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.SubjectTopics",
                c => new
                    {
                        Subject_Id = c.Long(nullable: false),
                        Topic_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Topic_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Topics", t => t.Topic_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Topic_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Students", "Person_Id", "dbo.People");
            DropForeignKey("dbo.HeadTeachers", "Person_Id", "dbo.People");
            DropForeignKey("dbo.SubjectTopics", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.SubjectTopics", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.TeacherTopics", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.TeacherTopics", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.TeacherSubjects", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.TeacherSubjects", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.HeadTeachers", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.SubjectClasses", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.SubjectClasses", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.TopicStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.TopicStudents", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.StudentClasses", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.StudentClasses", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Classes", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.HeadTeachers", "Id", "dbo.Classes");
            DropIndex("dbo.SubjectTopics", new[] { "Topic_Id" });
            DropIndex("dbo.SubjectTopics", new[] { "Subject_Id" });
            DropIndex("dbo.TeacherTopics", new[] { "Topic_Id" });
            DropIndex("dbo.TeacherTopics", new[] { "Teacher_Id" });
            DropIndex("dbo.TeacherSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.TeacherSubjects", new[] { "Teacher_Id" });
            DropIndex("dbo.SubjectClasses", new[] { "Class_Id" });
            DropIndex("dbo.SubjectClasses", new[] { "Subject_Id" });
            DropIndex("dbo.TopicStudents", new[] { "Student_Id" });
            DropIndex("dbo.TopicStudents", new[] { "Topic_Id" });
            DropIndex("dbo.StudentClasses", new[] { "Class_Id" });
            DropIndex("dbo.StudentClasses", new[] { "Student_Id" });
            DropIndex("dbo.Teachers", new[] { "Person_Id" });
            DropIndex("dbo.Students", new[] { "Person_Id" });
            DropIndex("dbo.HeadTeachers", new[] { "Person_Id" });
            DropIndex("dbo.HeadTeachers", new[] { "Teacher_Id" });
            DropIndex("dbo.HeadTeachers", new[] { "Id" });
            DropIndex("dbo.Classes", new[] { "SchoolId" });
            DropTable("dbo.SubjectTopics");
            DropTable("dbo.TeacherTopics");
            DropTable("dbo.TeacherSubjects");
            DropTable("dbo.SubjectClasses");
            DropTable("dbo.TopicStudents");
            DropTable("dbo.StudentClasses");
            DropTable("dbo.People");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Topics");
            DropTable("dbo.Students");
            DropTable("dbo.HeadTeachers");
            DropTable("dbo.Classes");
        }
    }
}
