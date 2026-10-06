using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.EntityFramework.Configurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {

            builder.ToTable("ShoppingCarts");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.CustomerId).IsRequired();
            // Maping: ShoppingCartItem doesnot have a direct relationship with ShoppingCart, so we need to configure it as an owned entity
            //lives inside the ShoppingCart table, so we need to configure it as an owned entity
            builder.OwnsMany(s => s.Items, item =>
            {
                item.ToTable("ShoppingCartItems");
                item.WithOwner().HasForeignKey("ShoppingCartId");
                item.Property(i=>i.ProductId).IsRequired();
                item.Property(i => i.ProductName).IsRequired().HasMaxLength(100);
                item.Property(i => i.ProductPrice).IsRequired().HasColumnType("decimal(18,2)");
                item.Property(i => i.Quantity).IsRequired();



            });
        }
    }
}
