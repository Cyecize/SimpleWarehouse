using SimpleWarehouse.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
