using System;

namespace TimeCare.Models
{
    public class ScheduleType
    {
        public int PassId { get; set; }
        public string PassName { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime EndTime { get { return StartTime + Duration; } set { this.EndTime = value; } }
        public string Description { get; set; }
        public TimeSpan ReminderDuration { get; set; }
    }
}