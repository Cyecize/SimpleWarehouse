using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    [Table("transaction_products")]
    public class TransactionProduct
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [ForeignKey("Product")]
        [Column("product_id")]
        public int ProductId { get; set; }

        [ForeignKey("Transaction")]
        [Column("transaction_id")]
        public int TransactionId { get; set; }

        [Column("product_quantity")]
        public double ProductQuantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual Transaction Transaction { get; set; }

        [NotMapped]
        public double SubTotalPrice { get; set; }

    }
}
