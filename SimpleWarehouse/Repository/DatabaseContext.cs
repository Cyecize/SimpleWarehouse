using System.Data.Common;
using System.Data.Entity;
using MySql.Data.Entity;
using SimpleWarehouse.Model;

namespace SimpleWarehouse.Repository
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("warehouse_db")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DatabaseContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection,
            contextOwnsConnection)
        {
            Configuration.LazyLoadingEnabled = true;
        }

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