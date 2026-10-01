using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Data
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id);

    }
}
