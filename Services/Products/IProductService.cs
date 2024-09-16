using System;

namespace Services.Products;

public interface IProductService
{
    Task<ServiceResult<IList<ProductResponse>>> GetTopPriceProductsAsync(int count);
    Task<ServiceResult<IList<ProductResponse>>> GetAllProductsAsync();
    Task<ServiceResult<ProductResponse?>> GetProductByIdAsync(int id);
    Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request);
    Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequest request);
    Task<ServiceResult> DeleteProductAsync(int id);
}
