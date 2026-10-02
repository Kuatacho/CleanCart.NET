using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.RemoveItemFromCart
{
    public class RemoveItemFromCartInput (Guid userId, Guid productId, int quantity)
    {
        public Guid UserId { get; } = userId;
        public Guid ProductId { get; } = productId;
        public int Quantity { get; } = quantity;

    }
}
