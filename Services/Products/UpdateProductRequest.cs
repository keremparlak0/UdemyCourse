using System;

namespace Services.Products;

public record UpdateProductRequest(int id, string Name, decimal Price, int Stock);
