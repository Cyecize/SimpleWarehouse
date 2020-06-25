using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SimpleWarehouse.Model.Enum;

namespace SimpleWarehouse.Model
{
    [Table("roles")]
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [Column("role")]
        [Required]
        [Index(IsUnique = true)]
        public RoleType RoleType { get; set; }
    }
}