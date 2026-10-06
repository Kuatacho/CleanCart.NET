using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructure.Persistence.EntityFramework
{
    public class CoreDbContext (DbContextOptions<CoreDbContext> options): DbContext(options)
    {
        public DbSet <Product> Products { get; set; }=null!;
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }=null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Search auto all classes that implement IEntityTypeConfiguration on this layer
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
