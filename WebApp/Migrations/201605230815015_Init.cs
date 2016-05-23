namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        IDNumber = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Status = c.String(),
                        ReportCopyType = c.String(),
                        ReportCopy = c.Binary(),
                    })
                .PrimaryKey(t => t.IDNumber);
            
            CreateTable(
                "dbo.AssignTeacherToClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffNumber = c.String(),
                        GradeGroupId = c.String(),
                        GradeGroup_ClassGroupe_id = c.String(maxLength: 128),
                        staffT_Stuff_Number = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassGroupes", t => t.GradeGroup_ClassGroupe_id)
                .ForeignKey("dbo.Staffs", t => t.staffT_Stuff_Number)
                .Index(t => t.GradeGroup_ClassGroupe_id)
                .Index(t => t.staffT_Stuff_Number);
            
            CreateTable(
                "dbo.ClassGroupes",
                c => new
                    {
                        ClassGroupe_id = c.String(nullable: false, maxLength: 128),
                        GroupeName = c.String(),
                        Grade_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ClassGroupe_id)
                .ForeignKey("dbo.Grades", t => t.Grade_id)
                .Index(t => t.Grade_id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Grade_id = c.String(nullable: false, maxLength: 128),
                        GradeName = c.String(),
                    })
                .PrimaryKey(t => t.Grade_id);
            
            CreateTable(
                "dbo.StudentTables",
                c => new
                    {
                        Student_Number = c.String(nullable: false, maxLength: 128),
                        Student_IDNumber = c.String(),
                        Student_Name = c.String(),
                        Student_Surname = c.String(),
                        Student_Date_Of_Birth = c.DateTime(nullable: false),
                        Enrolment_Date = c.DateTime(nullable: false),
                        Student_Gender = c.String(),
                        Student_Religion = c.String(),
                        Student_Adress = c.String(),
                        Grade_id = c.String(maxLength: 128),
                        ClassGroupe_id = c.String(maxLength: 128),
                        Parent_Identity = c.String(maxLength: 128),
                        Stream_Code = c.String(maxLength: 128),
                        Role = c.String(),
                        AddPhoto = c.Binary(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.Student_Number)
                .ForeignKey("dbo.ClassGroupes", t => t.ClassGroupe_id)
                .ForeignKey("dbo.Grades", t => t.Grade_id)
                .ForeignKey("dbo.Parents", t => t.Parent_Identity)
                .ForeignKey("dbo.StreamTables", t => t.Stream_Code)
                .Index(t => t.Grade_id)
                .Index(t => t.ClassGroupe_id)
                .Index(t => t.Parent_Identity)
                .Index(t => t.Stream_Code);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Markid = c.Int(nullable: false, identity: true),
                        ClassGroupID = c.String(),
                        Subject_Code = c.String(),
                        Term1 = c.Int(),
                        Term2 = c.Int(),
                        Term3 = c.Int(),
                        Term4 = c.Int(),
                        StudentID = c.String(),
                        Student_Student_Number = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Markid)
                .ForeignKey("dbo.StudentTables", t => t.Student_Student_Number)
                .Index(t => t.Student_Student_Number);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Parent_Identity = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Parent_Name = c.String(),
                        Parent_Surname = c.String(),
                        Parent_Number = c.String(),
                        Parent_Adress = c.String(),
                        Parent_Email = c.String(),
                    })
                .PrimaryKey(t => t.Parent_Identity);
            
            CreateTable(
                "dbo.StreamTables",
                c => new
                    {
                        Stream_Code = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Stream_Code);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Subject_Code = c.String(nullable: false, maxLength: 128),
                        DescriptiveTitle = c.String(),
                        Stream_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Subject_Code)
                .ForeignKey("dbo.StreamTables", t => t.Stream_Code)
                .Index(t => t.Stream_Code);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Stuff_Number = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Registration_Date = c.DateTime(nullable: false),
                        Gender = c.String(),
                        AddPhoto = c.Binary(),
                        IdentityNumber = c.String(),
                        ContactNumber = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Stuff_Number);
            
            CreateTable(
                "dbo.AssignTeacherToClassViewmodels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffNumber = c.String(nullable: false),
                        GradeGroupId = c.String(nullable: false),
                        GradeGroup_ClassGroupe_id = c.String(maxLength: 128),
                        staffT_Stuff_Number = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassGroupes", t => t.GradeGroup_ClassGroupe_id)
                .ForeignKey("dbo.Staffs", t => t.staffT_Stuff_Number)
                .Index(t => t.GradeGroup_ClassGroupe_id)
                .Index(t => t.staffT_Stuff_Number);
            
            CreateTable(
                "dbo.AssignTeacherToSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StaffNumber = c.String(),
                        GradeGroupId = c.String(),
                        SubjectCode = c.String(),
                        GradeGroup_ClassGroupe_id = c.String(maxLength: 128),
                        staffT_Stuff_Number = c.String(maxLength: 128),
                        SubjectT_Subject_Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassGroupes", t => t.GradeGroup_ClassGroupe_id)
                .ForeignKey("dbo.Staffs", t => t.staffT_Stuff_Number)
                .ForeignKey("dbo.Subjects", t => t.SubjectT_Subject_Code)
                .Index(t => t.GradeGroup_ClassGroupe_id)
                .Index(t => t.staffT_Stuff_Number)
                .Index(t => t.SubjectT_Subject_Code);
            
            CreateTable(
                "dbo.AttendReccords",
                c => new
                    {
                        AttendReccordID = c.Int(nullable: false, identity: true),
                        StudentNo = c.String(nullable: false),
                        StudentName = c.String(nullable: false),
                        GradeGroupID = c.String(nullable: false),
                        Day = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Attends = c.String(),
                        Absent = c.String(),
                        Await = c.String(),
                        Remark = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AttendReccordID);
            
            CreateTable(
                "dbo.Attends",
                c => new
                    {
                        AttendID = c.Int(nullable: false, identity: true),
                        StudentNo = c.String(nullable: false, maxLength: 13),
                        StudentName = c.String(nullable: false),
                        GradeGroupID = c.String(nullable: false),
                        Day = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Attends = c.String(nullable: false),
                        Absent = c.String(nullable: false),
                        Await = c.String(nullable: false),
                        Remark = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AttendID);
            
            CreateTable(
                "dbo.AttendViewModels",
                c => new
                    {
                        AttendID = c.Int(nullable: false, identity: true),
                        StudentNo = c.String(nullable: false, maxLength: 13),
                        StudentName = c.String(nullable: false),
                        Day = c.String(nullable: false),
                        GradeGroupID = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Attends = c.String(),
                        Absent = c.String(),
                        Await = c.String(),
                        Remark = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AttendID);
            
            CreateTable(
                "dbo.ClassMarks",
                c => new
                    {
                        Student_No = c.String(nullable: false, maxLength: 128),
                        Student_name = c.String(),
                        ClassGroupe_id = c.String(maxLength: 128),
                        Subject1 = c.String(),
                        mark = c.Int(),
                        Subject2 = c.String(),
                        mark21 = c.Int(),
                        Subject3 = c.String(),
                        mark12 = c.Int(),
                        Subject4 = c.String(),
                        mark23 = c.Int(),
                        Subject5 = c.String(),
                        mark32 = c.Int(),
                        Student_Student_Number = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Student_No)
                .ForeignKey("dbo.ClassGroupes", t => t.ClassGroupe_id)
                .ForeignKey("dbo.StudentTables", t => t.Student_Student_Number)
                .Index(t => t.ClassGroupe_id)
                .Index(t => t.Student_Student_Number);
            
            CreateTable(
                "dbo.ProgressReports",
                c => new
                    {
                        MarkID = c.Int(nullable: false),
                        ClassGroupID = c.String(),
                        Subject_Code = c.String(),
                        Term1 = c.Int(),
                        Term2 = c.Int(),
                        Term3 = c.Int(),
                        Term4 = c.Int(),
                        StudentID = c.String(),
                    })
                .PrimaryKey(t => t.MarkID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StudentMarks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Student_Number = c.String(),
                        Student_Name = c.String(),
                        ClassGroupe_id = c.String(maxLength: 128),
                        GroupeName = c.String(),
                        Subject_Code = c.String(maxLength: 128),
                        mark = c.Int(),
                        result = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassGroupes", t => t.ClassGroupe_id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Code)
                .Index(t => t.ClassGroupe_id)
                .Index(t => t.Subject_Code);
            
            CreateTable(
                "dbo.StudentMarkViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Student_Number = c.String(maxLength: 128),
                        Student_Name = c.String(),
                        ClassGroupe_id = c.String(maxLength: 128),
                        GroupeName = c.String(),
                        Subject_Code = c.String(maxLength: 128),
                        mark = c.Int(),
                        result = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassGroupes", t => t.ClassGroupe_id)
                .ForeignKey("dbo.StudentTables", t => t.Student_Number)
                .ForeignKey("dbo.Subjects", t => t.Subject_Code)
                .Index(t => t.Student_Number)
                .Index(t => t.ClassGroupe_id)
                .Index(t => t.Subject_Code);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StudentMarkViewModels", "Subject_Code", "dbo.Subjects");
            DropForeignKey("dbo.StudentMarkViewModels", "Student_Number", "dbo.StudentTables");
            DropForeignKey("dbo.StudentMarkViewModels", "ClassGroupe_id", "dbo.ClassGroupes");
            DropForeignKey("dbo.StudentMarks", "Subject_Code", "dbo.Subjects");
            DropForeignKey("dbo.StudentMarks", "ClassGroupe_id", "dbo.ClassGroupes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ClassMarks", "Student_Student_Number", "dbo.StudentTables");
            DropForeignKey("dbo.ClassMarks", "ClassGroupe_id", "dbo.ClassGroupes");
            DropForeignKey("dbo.AssignTeacherToSubjects", "SubjectT_Subject_Code", "dbo.Subjects");
            DropForeignKey("dbo.AssignTeacherToSubjects", "staffT_Stuff_Number", "dbo.Staffs");
            DropForeignKey("dbo.AssignTeacherToSubjects", "GradeGroup_ClassGroupe_id", "dbo.ClassGroupes");
            DropForeignKey("dbo.AssignTeacherToClassViewmodels", "staffT_Stuff_Number", "dbo.Staffs");
            DropForeignKey("dbo.AssignTeacherToClassViewmodels", "GradeGroup_ClassGroupe_id", "dbo.ClassGroupes");
            DropForeignKey("dbo.AssignTeacherToClasses", "staffT_Stuff_Number", "dbo.Staffs");
            DropForeignKey("dbo.AssignTeacherToClasses", "GradeGroup_ClassGroupe_id", "dbo.ClassGroupes");
            DropForeignKey("dbo.Subjects", "Stream_Code", "dbo.StreamTables");
            DropForeignKey("dbo.StudentTables", "Stream_Code", "dbo.StreamTables");
            DropForeignKey("dbo.StudentTables", "Parent_Identity", "dbo.Parents");
            DropForeignKey("dbo.Marks", "Student_Student_Number", "dbo.StudentTables");
            DropForeignKey("dbo.StudentTables", "Grade_id", "dbo.Grades");
            DropForeignKey("dbo.StudentTables", "ClassGroupe_id", "dbo.ClassGroupes");
            DropForeignKey("dbo.ClassGroupes", "Grade_id", "dbo.Grades");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.StudentMarkViewModels", new[] { "Subject_Code" });
            DropIndex("dbo.StudentMarkViewModels", new[] { "ClassGroupe_id" });
            DropIndex("dbo.StudentMarkViewModels", new[] { "Student_Number" });
            DropIndex("dbo.StudentMarks", new[] { "Subject_Code" });
            DropIndex("dbo.StudentMarks", new[] { "ClassGroupe_id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ClassMarks", new[] { "Student_Student_Number" });
            DropIndex("dbo.ClassMarks", new[] { "ClassGroupe_id" });
            DropIndex("dbo.AssignTeacherToSubjects", new[] { "SubjectT_Subject_Code" });
            DropIndex("dbo.AssignTeacherToSubjects", new[] { "staffT_Stuff_Number" });
            DropIndex("dbo.AssignTeacherToSubjects", new[] { "GradeGroup_ClassGroupe_id" });
            DropIndex("dbo.AssignTeacherToClassViewmodels", new[] { "staffT_Stuff_Number" });
            DropIndex("dbo.AssignTeacherToClassViewmodels", new[] { "GradeGroup_ClassGroupe_id" });
            DropIndex("dbo.Subjects", new[] { "Stream_Code" });
            DropIndex("dbo.Marks", new[] { "Student_Student_Number" });
            DropIndex("dbo.StudentTables", new[] { "Stream_Code" });
            DropIndex("dbo.StudentTables", new[] { "Parent_Identity" });
            DropIndex("dbo.StudentTables", new[] { "ClassGroupe_id" });
            DropIndex("dbo.StudentTables", new[] { "Grade_id" });
            DropIndex("dbo.ClassGroupes", new[] { "Grade_id" });
            DropIndex("dbo.AssignTeacherToClasses", new[] { "staffT_Stuff_Number" });
            DropIndex("dbo.AssignTeacherToClasses", new[] { "GradeGroup_ClassGroupe_id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.StudentMarkViewModels");
            DropTable("dbo.StudentMarks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProgressReports");
            DropTable("dbo.ClassMarks");
            DropTable("dbo.AttendViewModels");
            DropTable("dbo.Attends");
            DropTable("dbo.AttendReccords");
            DropTable("dbo.AssignTeacherToSubjects");
            DropTable("dbo.AssignTeacherToClassViewmodels");
            DropTable("dbo.Staffs");
            DropTable("dbo.Subjects");
            DropTable("dbo.StreamTables");
            DropTable("dbo.Parents");
            DropTable("dbo.Marks");
            DropTable("dbo.StudentTables");
            DropTable("dbo.Grades");
            DropTable("dbo.ClassGroupes");
            DropTable("dbo.AssignTeacherToClasses");
            DropTable("dbo.Applications");
        }
    }
}
