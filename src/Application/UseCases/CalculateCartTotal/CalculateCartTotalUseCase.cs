using Application.Interfaces.Data;
using Application.Interfaces.UseCases;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.CalculateCartTotal
{
    public class CalculateCartTotalUseCase (IShoppingCartRepository shoppingCartRepository): ICalculateCartTotalUseCase
    {
        
        public async Task<decimal> CalculateTotalAsync(CalculateCartTotalInput input)
        {
            var shoppingCart=await shoppingCartRepository.GetByUserIdAsync(input.UserId);

            decimal subtotal = CalculateSubtotal(shoppingCart);
            decimal taxes = CalculateTaxes(subtotal);
            return subtotal + taxes;
        }

        private decimal CalculateTaxes(decimal subtotal)
        {
            // For simplicity, let's assume a flat tax rate of 8%
           const decimal taxRate = 0.08m;
            return subtotal * taxRate;
        }

        private decimal CalculateSubtotal(ShoppingCart? shoppingCart)
        {
            return shoppingCart?.Items.Sum(item => item.ProductPrice *item.Quantity) ?? 0m;
        }
    }
}
