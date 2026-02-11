using System;

namespace Testing;

public class ProductService
{
    private readonly List<Product> _products = new()
    {
        new Product(1, "teclado", 10m),
        new Product(2, "mouse", 120m),
        new Product(3, "monitor", 15m),
        new Product(4, "tarjeta gráfica", 150m),
        new Product(5, "case", 300m)
    };

    public IEnumerable<Product> GetProductsByMinimumPrice(decimal minimumPrice)
    {
        return _products.Where(p => p.Price >= minimumPrice);
    }
}
