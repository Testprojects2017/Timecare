using System;
using System.ComponentModel.DataAnnotations;

namespace TimeCare.Models
{
    public class TrainSchedule
    {
        
        public int TrainScheduleId { get; set; }
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

        public int TrainScheduleTypeId { get; set; }

        public TimeSpan? ChangeoverTimeBefore { get; set; }
        public TimeSpan? ChangeoverTimeAfter { get; set; }
        public TrainType TrainType { get; set; }

    }

    public enum TrainType
    {
        Spinning,Boxing
    }
}