namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bill")]
    public partial class bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bill()
        {
            bill_detail = new HashSet<bill_detail>();
        }
        [DisplayName("Mã đơn hàng")]
        public int id { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày đặt")]
        public DateTime? create_date { get; set; }
        [DisplayName("Trạng thái đơn hàng")]
        public bool status { get; set; }
        [DisplayName("Ghi chú")]
        public string note { get; set; }
        [DisplayName("Tên khách hàng")]
        public string name { get; set; }
        [DisplayName("Địa chỉ email")]
        public string email { get; set; }
        [DisplayName("Số điện thoại")]
        public string phone { get; set; }
        public int? gender  { get; set; }
        [DisplayName("Địa chỉ")]
        public string address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill_detail> bill_detail { get; set; }
    }
}
