using Application.UseCases.RemoveItemFromCart;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.UseCases
{
    public interface IRemoveItemFromCartUseCase
    {
        Task RemoveItemFromCartAsync(RemoveItemFromCartInput input);

    }
}
