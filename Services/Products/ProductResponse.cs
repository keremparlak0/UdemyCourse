using System;

namespace Services.Products;

public record ProductResponse(int Id, string Name, decimal Price, int Stock);

// public record ProductResponse
// {
//     public int Id { get; init; }
//     public string Name { get; init; }
//     public decimal Price { get; init; }
//     public int Stock { get; init; }
// }

