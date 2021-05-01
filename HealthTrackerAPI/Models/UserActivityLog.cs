using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthTrackerAPI.Models
{
    public class UserActivityLog
    {
        public string UserId { get; set; }
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int ActiveMinutes { get; set; }
        public int CaloriesBurnt { get; set; }
    }
}
