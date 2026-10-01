using Application.Interfaces.Data;
using Application.UseCases.AddItemToCart;
using Domain.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UnitTests.UseCases
{
    public class AddItemToCartUseCaseTests
    {
        [Fact]
        public async Task AddItemToCartAsync_ValidInput_AddsItemToCart()
        {
            // arrange, prepare scenario, mock dependencies, and set up test data

            //1. Create mocks for repositories interfaces
            var shoppingCartRepository = Substitute.For<IShoppingCartRepository>();
            var productRepository = Substitute.For<IProductRepository>();

            var userId = Guid.NewGuid();
            var shoppingCart = new ShoppingCart(userId); 
            var product = new Product("Producto de Prueba", 10.00m, 5, "https://example.com/item.jpg");

            // 2. Configure the mock repositories to return the expected data
            shoppingCartRepository.GetByUserIdAsync(userId).Returns(shoppingCart);
            productRepository.GetByIdAsync(product.Id).Returns(product);

            var useCase = new AddItemToCartUseCase(shoppingCartRepository, productRepository); 
            var input = new AddItemToCartInput(userId, product.Id, 1);

            // act
            await useCase.AddItemToCartAsync(input);

            // assert
            //verify that the item was added to the shopping cart
            await productRepository.Received(1).GetByIdAsync(product.Id); 
            await shoppingCartRepository.Received(1).GetByUserIdAsync(userId);
            await shoppingCartRepository.Received(1).SaveAsync(shoppingCart);


        }

        [Fact]
        public async Task AddItemToCartAsync_ShouldCreateNewCart_WhenCartDoesNotExist()
        {
            // Arrange
            var shoppingCartRepository = Substitute.For<IShoppingCartRepository>();
            var productRepository = Substitute.For<IProductRepository>();

            var userId = Guid.NewGuid();
            var product = new Product("Producto de Prueba", 10.00m, 5, "https://example.com/item.jpg");

            // Simulate that a user does not have an existing shopping cart
            shoppingCartRepository.GetByUserIdAsync(userId).Returns((ShoppingCart)null);
            productRepository.GetByIdAsync(product.Id).Returns(product);
            var useCase = new AddItemToCartUseCase(shoppingCartRepository, productRepository);
            var input = new AddItemToCartInput(userId, product.Id, 2);
            //act
            await useCase.AddItemToCartAsync(input);
            //assert, verify that saveAsync was called with a new shopping cart containing the item and correct quantity
            await shoppingCartRepository.Received(1).SaveAsync(Arg.Is<ShoppingCart>(cart =>
                cart.CustomerId == userId &&
                cart.Items.Any(i => i.ProductId == product.Id && i.Quantity == 2)
            ));


        }




    }
}
