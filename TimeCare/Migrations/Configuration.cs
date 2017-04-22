namespace TimeCare.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TimeCare;

    internal sealed class Configuration : DbMigrationsConfiguration<TimeCare.Models.TimeCareContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TimeCare.Models.TimeCareContext context)
        {

            var workSchedules = new[]
            {
                new WorkSchedule {PassName="Work Task 1", StartTime = DateTime.Parse("2017-04-01 08:00:00"), Duration=TimeSpan.Parse("01:30:00"),Description="Task 1", },
                new WorkSchedule {PassName="Work Task 2", StartTime = DateTime.Parse("2017-04-01 10:00:00"), Duration=TimeSpan.Parse("01:30:00"),Description="Task 2" },
                new WorkSchedule {PassName="Work Task 3", StartTime = DateTime.Parse("2017-04-01 13:00:00"), Duration=TimeSpan.Parse("01:30:00"),Description="Task 3" },
                new WorkSchedule {PassName="Work Task 4", StartTime = DateTime.Parse("2017-04-01 14:30:00"), Duration=TimeSpan.Parse("01:30:00"),Description="Task 4" },
            };
            context.WorkSchedules.AddOrUpdate(workSchedules);
            context.SaveChanges();

            var socialSchedules = new[]
           {
                new SocialSchedule {PassName="Meeting 1", StartTime = DateTime.Parse("2017-04-01 17:00:00"), Duration=TimeSpan.Parse("00:15:00"),Description="Meeting 1" },
                new SocialSchedule {PassName="Meeting 2", StartTime = DateTime.Parse("2017-04-01 17:30:00"), Duration=TimeSpan.Parse("00:15:00"),Description="Meeting 2" },
                new SocialSchedule {PassName="Meeting 3", StartTime = DateTime.Parse("2017-04-01 18:00:00"), Duration=TimeSpan.Parse("00:15:00"),Description="Meeting 3" },
                new SocialSchedule {PassName="Party", StartTime = DateTime.Parse("2017-04-01 18:30:00"), Duration=TimeSpan.Parse("01:00:00"),Description="Party" },
            };

            context.SocialSchedules.AddOrUpdate(socialSchedules);
            context.SaveChanges();

            var trainSchedules = new[]
           {
                new TrainSchedule {PassName="Train 1", StartTime = DateTime.Parse("2017-04-01 20:30:00"), Duration=TimeSpan.Parse("00:30:00"),ChangeoverTimeBefore=TimeSpan.Parse("00:10:00"),ChangeoverTimeAfter=TimeSpan.Parse("00:10:00"),Description="Training Boxing " ,TrainType=TrainType.Boxing},
                new TrainSchedule {PassName="Train 2", StartTime = DateTime.Parse("2017-04-01 22:30:00"), Duration=TimeSpan.Parse("00:30:00"),ChangeoverTimeBefore=TimeSpan.Parse("00:10:00"),ChangeoverTimeAfter=TimeSpan.Parse("00:10:00"),Description="Training Spinning" ,TrainType=TrainType.Spinning},

            };

            context.TrainSchedules.AddOrUpdate(trainSchedules);
            context.SaveChanges();


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
