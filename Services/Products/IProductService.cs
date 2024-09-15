using System;

namespace Services.Products;

public interface IProductService
{
    public Task<ServiceResult<IList<ProductResponse>>> GetTopPriceProductsAsync(int count);
    public Task<ServiceResult<ProductResponse>> GetProductByIdAsync(int id);
    public Task<ServiceResult<CreateProductResponse>> CreateProductAsync(CreateProductRequest request);
    public Task<ServiceResult> UpdateProductAsync(int id, UpdateProductRequest request);
    public Task<ServiceResult> DeleteProductAsync(int id);
}
