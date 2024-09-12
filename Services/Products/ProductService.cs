using System;
using Repositories;
using Repositories.Products;

namespace Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productsRepository;

    public ProductService(IProductRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public Task<IList<Product>> GetTopPriceProductsAsync(int count)
    {
        return _productsRepository.GetTopPriceProductsAsync(count);
    }
}
