using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleWarehouse.Model.Enum;

namespace SimpleWarehouse.Model
{
    [Table("search_params")]
    public class SearchParameter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index(IsUnique = true)]
        [Column("id")]
        public int Id { get; set; }

        [Column("display_name")]
        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [Column("search_type")] public SearchType SearchType { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}