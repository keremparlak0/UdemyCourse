using System;

namespace Repositories.Products;

public interface IProductRepository : IGenericRepository<Product>
{
    public Task<IList<Product>> GetTopPriceProductsAsync(int count);
}
