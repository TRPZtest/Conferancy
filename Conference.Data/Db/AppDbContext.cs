using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Conferency.Data.Db
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<SortingColumn> SortingColumns { get; set; }
        public virtual DbSet<SortingProperty> SortingProperties { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersView> UsersViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {       
            modelBuilder.Entity<Region>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);
               
            modelBuilder.Entity<SortingColumn>()
                .HasMany(e => e.SortingProperties)
                .WithRequired(e => e.SortingColumn)
                .WillCascadeOnDelete(false);                        
        }
    }
}
