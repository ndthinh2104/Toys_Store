using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Toys.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Mời nhập tên đăng nhập")]
        public string username { get; set; }
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        public string password { get;set; }
        public bool rememberMe { get; set; }

    }
}