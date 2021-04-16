using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HBealthTrackerAPI.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }
    }
}