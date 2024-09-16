using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Products;

namespace WebApi.Controllers
{
    public class ProductsController(IProductService _productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProducts() => CreateActionResult(await _productService.GetAllProductsAsync());


        [HttpGet]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await _productService.GetProductByIdAsync(id));


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request) => CreateActionResult(await _productService.CreateProductAsync(request));


        [HttpPut]
        public async Task<IActionResult> Update(int id, UpdateProductRequest request) => CreateActionResult(await _productService.UpdateProductAsync(id, request));


        [HttpDelete]
        public async Task<IActionResult> Delete(int id) => CreateActionResult(await _productService.DeleteProductAsync(id));
    }


}
