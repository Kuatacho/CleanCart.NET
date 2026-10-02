using Application.UseCases.CalculateCartTotal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.UseCases
{
    public interface ICalculateCartTotalUseCase
    {
        Task<decimal> CalculateTotalAsync (CalculateCartTotalInput input);
    }
}
