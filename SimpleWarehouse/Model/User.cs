using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Model
{
    [Table("users")]
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [Column("username")]
        [Index(IsUnique = true)]
        [StringLength(maximumLength: 50)]
        [Required]
        public string Username { get; set; }

        [Column("password")]
        [StringLength(maximumLength: 255)]
        [Required]
        public string Password { get; set; }

        [Column("date_registered")]
        [Required]
        public DateTime RegisterDate { get; set; }

        [Column("is_enabled")]
        [Required]
        public bool IsEnabled { get; set; }

        public virtual List<Role> Roles { get; set; }

        public User()
        {
            this.IsEnabled = true;
            this.RegisterDate = DateTime.Now;
            this.Roles = new List<Role>();
        }

        public override string ToString()
        {
            return this.Username;
        }
    }
}
