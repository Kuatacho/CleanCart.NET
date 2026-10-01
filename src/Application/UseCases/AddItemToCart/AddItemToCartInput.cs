using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.AddItemToCart
{
    public class AddItemToCartInput (Guid userId, Guid productId, int quantity)
    {
        public Guid UserId { get; } 
        public Guid ProductId { get; } 
        public int Quantity { get; } 

    }
}
