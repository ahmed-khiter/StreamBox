using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StreamBox.Models
{
    public class Users
    {
        public int id { get; set; }

        [Required(ErrorMessage = "You must enter user name")]
        [Display(Name ="User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must enter password")]
        public string Password { get; set; }

    }
}
