using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bai10_OnlineShhop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhập user name nhé")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời nhập pass word nhé")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}