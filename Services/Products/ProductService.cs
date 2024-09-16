using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Products;

namespace Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productsRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productsRepository, IUnitOfWork unitOfWork)
    {
        _productsRepository = productsRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<ServiceResult<IList<ProductResponse>>> GetTopPriceProductsAsync(int count)
    {
        var products = await _productsRepository.GetTopPriceProductsAsync(count);

        var productsAsDto = products.Select(x => new ProductResponse(x.Id, x.Name, x.Price, x.Stock)).ToList();

        return new ServiceResult<IList<ProductResponse>>()
        {
            Data = productsAsDto,
        };
    }


    public async Task<ServiceResult<IList<ProductResponse>>> GetAllProductsAsync()
    {
        var products = await _productsRepository.GetAll().ToListAsync();

        var productsAsDto = products.Select(x => new ProductResponse(x.Id, x.Name, x.Price, x.Stock)).ToList();

        return ServiceResult<IList<ProductResponse>>.Success(productsAsDto); 
        
    }

    public async Task<ServiceResult<ProductResponse?>> GetProductByIdAsync(int id)
    {
        var product = await _productsRepository.GetByIdAsync(id);
        if (product is null)
        {
            ServiceResult<ProductResponse>.Failure("Product not found");
        }

        var productsAsDto = new ProductResponse(product!.Id, product.Name, product.Price, product.Stock);

        return ServiceResult<ProductResponse>.Success(productsAsDto)!; //product cant be null
    }

    public async Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request)
    {
        var product = new Product()
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        };

        await _productsRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        return ServiceResult<CreateProductResponse>.Success(new CreateProductResponse(product.Id));
    }

    public async Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequest request)
    {
        var product = await _productsRepository.GetByIdAsync(id);

        if (product is null) // Fast Fail
        {
            ServiceResult.Failure("Product not found", HttpStatusCode.NotFound);
        }

        product.Name = request.Name;
        product.Price = request.Price;
        product.Stock = request.Stock;

        _productsRepository.Update(product);
        await _unitOfWork.SaveChangesAsync();

        return ServiceResult.Success();
    }

    public async Task<ServiceResult> DeleteProductAsync(int id)
    {
        var product = await _productsRepository.GetByIdAsync(id);
        if (product is null) return ServiceResult.Failure("Product not found", HttpStatusCode.NotFound);

        _productsRepository.Delete(product);
        await _unitOfWork.SaveChangesAsync();
        
        return ServiceResult.Success();
    }

}
