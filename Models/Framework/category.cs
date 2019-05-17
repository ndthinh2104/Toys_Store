﻿namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("category")]
    public partial class category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public category()
        {
            products = new HashSet<product>();
        }
        [DisplayName("ID")]
        public int id { get; set; }

        [StringLength(100, ErrorMessage ="Không được nhập quá 100 kí tự")]
        [DisplayName("Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public string name { get; set; }
        [DisplayName("Danh mục cha")]
        public int? parent_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<product> products { get; set; }
    }
}
