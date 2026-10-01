using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ShoppingCart (Guid customerId): IEntityId<Guid>
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid CustomerId { get; } = customerId;

        //Ocultamos la lista mutable en un campo privado
        private readonly List<ShoppingCartItem> _items = new();

        // Exponemos la lista de items como una colección de solo lectura
        public IReadOnlyCollection<ShoppingCartItem> Items => _items.AsReadOnly();

        //Metodo de negocio
        public void AddItem(Guid productId, string productName, decimal productPrice, int quantity)
        {
            var existingItem = _items.SingleOrDefault(i=>i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
               
                _items.Add(new ShoppingCartItem(productId, productName, productPrice, quantity));
            }

            
        }


    }
}
