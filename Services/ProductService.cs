using System;
using Repositories;
using Repositories.Products;

namespace Services;

public class ProductService
{
    private readonly IProductRepository _productsRepository;

    public ProductService(IProductRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }
}
