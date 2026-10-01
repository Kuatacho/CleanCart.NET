using Application.UseCases.AddItemToCart;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.UseCases
{
    public interface IAddItemToCartUseCase
    {
        Task AddItemToCartAsync (AddItemToCartInput input);

    }
}
