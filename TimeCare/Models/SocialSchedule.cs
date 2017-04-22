using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeCare.Models
{
    public class SocialSchedule
    {
        
        public int SocialScheduleId { get; set; }
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
        public int SocialScheduleTypeId { get; set; }
    }
}