using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StreamBox.ViewModels
{
    public class RegisterViewModel
    {
        
        [Display(Name = "User Name")]
        [Remote(action: "IsUserNameInUse", controller: "Account")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
