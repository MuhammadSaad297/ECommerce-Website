namespace ECommerce_Website.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int Product_ID { get; set; }

        [StringLength(50)]
        public string Product_Name { get; set; }

        [StringLength(100)]
        public string Product_Description { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Product_PurchasePrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Product_SalePrice { get; set; }

        [StringLength(200)]
        public string Product_Picture { get; set; }

        [NotMapped]
        public HttpPostedFileBase Pro_Pic { get; set; }

        [NotMapped]
        public int Pro_Quantity { get; set; }

        public int Category_FID { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
