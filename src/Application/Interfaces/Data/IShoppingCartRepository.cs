using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Data
{
    public interface IShoppingCartRepository
    {
        Task<ShoppingCart?> GetByUserIdAsync(Guid userId);
        Task SaveAsync (ShoppingCart shoppingCart);

    }
}
