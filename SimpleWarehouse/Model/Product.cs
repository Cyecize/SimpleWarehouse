using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    [Table("products")]
    public  class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [ForeignKey("Category")]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Required]
        [Column("product_name")]
        [StringLength(maximumLength: 45)]
        public string ProductName { get; set; }

        [Column("quantity")]
        public double Quantity { get; set; }

        [Column("import_price")]
        public double ImportPrice { get; set; }

        [Column("sell_price")]
        public double SellPrice { get; set; }

        [Column("is_visible")]
        public bool IsVisible { get; set; }

        public virtual Category Category { get; set; }

        public Product()
        {
            this.IsVisible = true;
        }
    }
}
