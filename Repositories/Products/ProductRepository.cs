using System;
using System.IO.Compression;

namespace Repositories.Products;

public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
{
    public async Task<IList<Product>> GetTopPriceProductsAsync(int count)
    {
        return await Context.Products.OrderByDescending(x => x.Price).Take(count).ToListAsync();
    }
}
