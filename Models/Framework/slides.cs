namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("slide")]
    public partial class slide
    { 

        [DisplayName("Mã")]
        public int? id { get; set; }
        [StringLength(100)]
        [DisplayName("Đường dẫn")]
        [Required(ErrorMessage = "Đường dẫn không được để trống")]
        public string link { get; set; }
        [StringLength(100)]
        [DisplayName("Ảnh")]
        [Required(ErrorMessage = "Ảnh không được để trống")]

        public string image { get; set; }
        
    }
}
