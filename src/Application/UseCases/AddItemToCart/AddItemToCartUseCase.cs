using Application.Interfaces.Data;
using Application.Interfaces.UseCases;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.AddItemToCart
{
    public class AddItemToCartUseCase(IShoppingCartRepository shoppingCartRepository,IProductRepository productRepository)
        : IAddItemToCartUseCase
    {

        public async Task AddItemToCartAsync(AddItemToCartInput input)
        {

            //Get the product from the repository
            var product = await productRepository.GetByIdAsync(input.ProductId);

            if (product == null)
            {
                throw new ArgumentException($"Product with id {input.ProductId} not found.");
            }

            // Get the shopping cart for the user or create a new one if it doesn't exist
            var shoppingCart = await shoppingCartRepository.GetByUserIdAsync(input.UserId) ?? new ShoppingCart(input.UserId);

            // Execute the business logic inside the domain entity
            shoppingCart.AddItem(product.Id, product.Name, product.Price, input.Quantity);

            // Persist the changes to the shopping cart
            await shoppingCartRepository.SaveAsync(shoppingCart);



            throw new NotImplementedException();
        }
    }
}
