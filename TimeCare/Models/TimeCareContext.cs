using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TimeCare.Models
{
    public class TimeCareContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TimeCareContext() : base("name=TimeCareContext")
        {
        }

        public System.Data.Entity.DbSet<TimeCare.Models.WorkSchedule> WorkSchedules { get; set; }

        public System.Data.Entity.DbSet<TimeCare.Models.Pass> Passes { get; set; }

        public System.Data.Entity.DbSet<TimeCare.Models.SocialSchedule> SocialSchedules { get; set; }

        public System.Data.Entity.DbSet<TimeCare.Models.TrainSchedule> TrainSchedules { get; set; }
    }
}
