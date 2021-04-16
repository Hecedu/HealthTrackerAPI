using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthTrackerAPI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}