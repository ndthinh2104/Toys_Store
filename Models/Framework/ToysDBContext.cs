namespace Models.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ToysDBContext : DbContext
    {
        public ToysDBContext()
            : base("name=ToysDBContext")
        {
        }

        public virtual DbSet<bill> bills { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<manufacturer> manufacturers { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<bill_detail> bill_detail { get; set; }
        public virtual DbSet<slide> slides { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bill>()
                .HasMany(e => e.bill_detail)
                .WithRequired(e => e.bill)
                .HasForeignKey(e => e.bill_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<category>()
                .HasMany(e => e.products)
                .WithRequired(e => e.category)
                .HasForeignKey(e => e.category_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<manufacturer>()
                .HasMany(e => e.products)
                .WithRequired(e => e.manufacturer)
                .HasForeignKey(e => e.manufacturer_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<product>()
                .Property(e => e.price_old)
                .HasPrecision(18, 0);

            modelBuilder.Entity<product>()
                .Property(e => e.big_photo)
                .IsFixedLength();

            modelBuilder.Entity<product>()
                .HasMany(e => e.bill_detail)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.product_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsFixedLength();

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsFixedLength();

            modelBuilder.Entity<bill_detail>()
                .Property(e => e.price)
                .HasPrecision(18, 0);
        }
    }
}
