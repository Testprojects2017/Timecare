using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeCare.Models
{
    public class Pass
    {
        public int PassId { get; set; }
        public string PassName { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get { return StartTime + Duration; } set { EndTime = StartTime + Duration; } }
        public string Description { get; set; }

        public int ScheduleTypeID { get; set; }
        
     
    }
}