using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.CalculateCartTotal
{
    public class CalculateCartTotalInput (Guid userId)
    {
        public Guid UserId { get; } = userId;

    }
}
