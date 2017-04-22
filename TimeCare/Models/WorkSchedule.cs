using System;
using System.ComponentModel.DataAnnotations;

namespace TimeCare.Models
{
    public class WorkSchedule
    {
        
        public int WorkScheduleId { get; set; }
        [Display(Name = "Pass Name")]
        public string PassName { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }
        [Display(Name = "Reminder Duration")]
        public TimeSpan? ReminderDuration { get; set; }
        public int WorkScheduleTypeId { get; set; }
    }
}