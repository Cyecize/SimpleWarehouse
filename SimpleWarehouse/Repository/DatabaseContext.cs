using MySql.Data.Entity;
using SimpleWarehouse.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouse.Repository
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionProduct> TransactionProducts { get; set; }
        public DbSet<Revision> Revisions { get; set; }
        public DbSet<SearchParameter> SearchParameters { get; set; }

        public DatabaseContext() : base("warehouse_db")
        {
            base.Configuration.LazyLoadingEnabled = true;    
        }

        public DatabaseContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {
            base.Configuration.LazyLoadingEnabled = true;
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany() //add property name if inversed
                .Map(m =>
                {
                    m.ToTable("users_roles");
                    m.MapLeftKey("user_id");
                    m.MapRightKey("role_id");
                });
        }
    }
}
