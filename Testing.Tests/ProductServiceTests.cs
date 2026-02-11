using System;

namespace Testing.Tests;

public class ProductServiceTests
{
    [Fact]
    public void GetProductsByMinimumPrice_MinimumPrice30_ReturnsAtLeastOneProduct()
    {
        // arrange
        var service = new ProductService();
        var minimumPrice = 30m;

        // act
        var result = service.GetProductsByMinimumPrice(minimumPrice).ToList();

        // assert
        Assert.NotEmpty(result);
    }

    [Fact]
    public void GetProductsByMinimumPrice_MinimumPrice30_ReturnsOnlyProductWithPriceGreaterThanOrEqualTo30()
    {
        // arrange
        var service = new ProductService();
        var minimumPrice = 30m;

        // act
        var result = service.GetProductsByMinimumPrice(minimumPrice).ToList();

        // assert
        Assert.All(result, product =>
        {
            Assert.True(product.Price >= minimumPrice);
        });
    }

    [Fact]
    public void GetProductsByMinimumPrice_MinimumPrice30_DoesNotReturnsProductsCheaperThan30()
    {
        // arrange
        var service = new ProductService();
        var minimumPrice = 30m;

        // act
        var result = service.GetProductsByMinimumPrice(minimumPrice).ToList();

        // assert
        Assert.DoesNotContain(result, product => product.Price < minimumPrice);
    }

    [Fact]
    public void GetProductsByMinimumPrice_GivenVeryHighMinimumPrice_ReturnsEmptyCollection()
    {
        // arrange
        var service = new ProductService();
        var minimumPrice = 400m;

        // act
        var result = service.GetProductsByMinimumPrice(minimumPrice);

        // assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetProductsByMinimumPrice_GivenMinimum0_ReturnsAllProducts()
    {
        // arrange
        var service = new ProductService();
        var minimumPrice = 0;

        // act
        var result = service.GetProductsByMinimumPrice(minimumPrice).ToList();

        // assert
        Assert.Equal(5, result.Count());
    }

    [Fact]
    public void GetProductsByMinimumPrice_GivenMinimum150_ReturnsGrafiCardAndCase()
    {
        // arrange
        var service = new ProductService();
        var minimumPrice = 150m;

        // act
        var result = service.GetProductsByMinimumPrice(minimumPrice).ToList();

        // assert
        Assert.Collection(result,
        product =>
        {
            Assert.Equal(4, product.Id);
            Assert.Equal("tarjeta gráfica", product.Name);
            Assert.Equal(150m, product.Price);
        },
        product =>
        {
            Assert.Equal(5, product.Id);
            Assert.Equal("case", product.Name);
            Assert.Equal(300m, product.Price);
        }
        );
    }
}
