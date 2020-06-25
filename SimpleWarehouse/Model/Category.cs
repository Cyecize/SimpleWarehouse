using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWarehouse.Model
{
    [Table("categories")]
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [Column("category_name")]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string CategoryName { get; set; }

        [ForeignKey("ParentCategory")]
        [Column("parent_id")]
        public int? ParentId { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual List<Category> SubCategories { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}