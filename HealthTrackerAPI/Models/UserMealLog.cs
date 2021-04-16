using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthTrackerAPI.Models
{
    public class UserMealLog
    {
        public string UserId { get; set; }  
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Calories { get; set; }
    }
}
