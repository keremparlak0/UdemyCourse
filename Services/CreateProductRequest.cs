using System;

namespace Services;

public record CreateProductRequest
{
    public string Name { get; init; }
    public decimal Price { get; init; }
    public int Stock { get; init; }
}
