using Application.Interfaces.Data;
using Domain.Entities;
using Infrastructure.Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class EfProductRepository(CoreDbContext context) : IProductRepository
    {
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
