using Microsoft.EntityFrameworkCore;
using onion_architecture.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion_architecture.Infrastructure.Context
{
    public class onion_architecture_Context:DbContext
    {
        public onion_architecture_Context(DbContextOptions<onion_architecture_Context> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Fruit> Fruits { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(e => e.UserId);
                e.ToTable("User");
            });
            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Categories");
                e.HasKey(e => e.CategoriesId);
            });
            modelBuilder.Entity<Fruit>(e =>
            {
                e.ToTable("Fruits");
                e.HasKey(e => e.FruitId);
                e.HasOne(e=>e.Category).WithMany(e=>e.Fruits).HasForeignKey(e=>e.CategoriesId).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e=>e.Store).WithMany(e=>e.Fruits).HasForeignKey(e=>e.StoreId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Cart>(e =>
            {
                e.ToTable("Carts");
                e.HasKey(e => e.CartId);
                e.HasOne(e => e.Fruit).WithMany(e => e.Carts).HasForeignKey(e => e.FruitId).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e => e.User).WithMany(e => e.Carts).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Store>(e =>
            {
                e.ToTable("Stores");
                e.HasKey(e => e.StoreId);
            });
        }
    }
}
