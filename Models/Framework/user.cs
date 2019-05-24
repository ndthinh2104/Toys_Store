namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        [DisplayName("ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(50)]
        [DisplayName("Tên đăng nhập")]
        public string username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        public string password { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Họ tên không được để trống")]
        [DisplayName("Họ và tên")]
        public string fullname { get; set; }

        public int? permission { get; set; }
        public int? status { get; set; }
        [DisplayName("Địa chỉ email")]
        [Required(ErrorMessage = "Địa chỉ Email không được để trống")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập đúng định dạng Email")]
        public string email { get; set; }
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string address { get; set; }
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string phone { get; set; }
        [DisplayName("Giới tính")]
        public int? gender { get; set; }


    }
}
