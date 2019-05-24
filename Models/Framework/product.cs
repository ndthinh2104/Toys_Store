namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            bill_detail = new HashSet<bill_detail>();
        }
        [DisplayName("ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100)]
        [DisplayName("Tên sản phẩm")]
        public string name { get; set; }
        [DisplayName("Trạng thái")]
        public int? available { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Mô tả sản phẩm không được để trống")]
        [DisplayName("Mô tả ")]
        public string description { get; set; }

        [DisplayName("Giá khuyến mãi")]
        [Required(ErrorMessage = "Giá khuyến mãi không được để trống")]
        public decimal price { get; set; }
        
        [DisplayName("Giá sản phẩm")]
        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        public decimal? price_old { get; set; }
        [DisplayName("Danh mục")]
        public int category_id { get; set; }
        [DisplayName("Nhà sản xuất")]
        public int manufacturer_id { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Ảnh sản phẩm không được để trống")]
        [DisplayName("Ảnh minh họa")]
        public string big_photo { get; set; }
        [DisplayName("Cách chơi")]
        public string rules { get; set; }

        public virtual category category { get; set; }

        public virtual manufacturer manufacturer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill_detail> bill_detail { get; set; }
    }
}
