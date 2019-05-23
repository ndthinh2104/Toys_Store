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

        [Required]
        [StringLength(50)]
        [DisplayName("Tên đăng nhập")]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Mật khẩu")]
        public string password { get; set; }

        [StringLength(100)]
        [DisplayName("Họ và tên")]
        public string fullname { get; set; }

        public int? permission { get; set; }
        public int? status { get; set; }
        [DisplayName("Địa chỉ email")]
        public string email { get; set; }
        [DisplayName("Địa chỉ")]
        public string address { get; set; }
        [DisplayName("Số điện thoại")]
        public string phone { get; set; }
        [DisplayName("Giới tính")]
        public int? gender { get; set; }


    }
}
