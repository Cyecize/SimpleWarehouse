using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWarehouse.Model
{
    [Table("users")]
    public class User
    {
        public User()
        {
            IsEnabled = true;
            RegisterDate = DateTime.Now;
            Roles = new List<Role>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [Index(IsUnique = true)]
        public int Id { get; set; }

        [Column("username")]
        [Index(IsUnique = true)]
        [StringLength(50)]
        [Required]
        public string Username { get; set; }

        [Column("password")]
        [StringLength(255)]
        [Required]
        public string Password { get; set; }

        [Column("date_registered")] [Required] public DateTime RegisterDate { get; set; }

        [Column("is_enabled")] [Required] public bool IsEnabled { get; set; }

        public virtual List<Role> Roles { get; set; }

        public override string ToString()
        {
            return Username;
        }
    }
}