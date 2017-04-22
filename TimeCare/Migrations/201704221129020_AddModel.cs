namespace TimeCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Passes",
                c => new
                    {
                        PassId = c.Int(nullable: false, identity: true),
                        PassName = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        EndTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        ScheduleTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PassId);
            
            CreateTable(
                "dbo.SocialSchedules",
                c => new
                    {
                        SocialScheduleId = c.Int(nullable: false, identity: true),
                        PassName = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Description = c.String(),
                        ReminderDuration = c.Time(precision: 7),
                        SocialScheduleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SocialScheduleId);
            
            CreateTable(
                "dbo.TrainSchedules",
                c => new
                    {
                        TrainScheduleId = c.Int(nullable: false, identity: true),
                        PassName = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Description = c.String(),
                        ReminderDuration = c.Time(precision: 7),
                        TrainScheduleTypeId = c.Int(nullable: false),
                        ChangeoverTimeBefore = c.Time(precision: 7),
                        ChangeoverTimeAfter = c.Time(precision: 7),
                        TrainType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TrainScheduleId);
            
            CreateTable(
                "dbo.WorkSchedules",
                c => new
                    {
                        WorkScheduleId = c.Int(nullable: false, identity: true),
                        PassName = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Description = c.String(),
                        ReminderDuration = c.Time(precision: 7),
                        WorkScheduleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkScheduleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.WorkSchedules");
            DropTable("dbo.TrainSchedules");
            DropTable("dbo.SocialSchedules");
            DropTable("dbo.Passes");
        }
    }
}
