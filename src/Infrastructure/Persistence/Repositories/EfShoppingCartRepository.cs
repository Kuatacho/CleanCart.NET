using Application.Interfaces.Data;
using Domain.Entities;
using Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class EfShoppingCartRepository(CoreDbContext context) : IShoppingCartRepository
    {
        public async Task<ShoppingCart?> GetByUserIdAsync(Guid userId)
        {
            //Its fundamenta use .Include to load the items of the shopping cart
            return await context.ShoppingCarts
                .Include(sc => sc.Items)
                .FirstOrDefaultAsync(sc => sc.CustomerId == userId);

        }

        public async Task SaveAsync(ShoppingCart shoppingCart)
        {
            var existingCart = await context.ShoppingCarts
                .FirstOrDefaultAsync(s=>s.Id == shoppingCart.Id);

            if (existingCart == null)
            {
                await context.ShoppingCarts.AddAsync(shoppingCart);

            }
            else
            {
                context.ShoppingCarts.Update(shoppingCart);
            }
            await context.SaveChangesAsync();
        }
    }
}
