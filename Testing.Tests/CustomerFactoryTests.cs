using System;

namespace Testing.Tests;

public class CustomerFactoryTests
{
    [Fact]
    public void Create_WithFewYears_ReturnsRegularCustomer()
    {
        var customer = CustomerFactory.Create("Marcelo", 2);
        Assert.IsType<Customer>(customer);
        Assert.IsNotType<LoyalCustomer>(customer);
    }

    [Fact]
    public void Create_WithFiveOrMoreYears_ReturnsLoyalCustomer()
    {
        var customer = CustomerFactory.Create("Marcelo", 10);
        Assert.IsType<LoyalCustomer>(customer);
        Assert.IsNotType<Customer>(customer);
    }

    [Theory]
    [InlineData(0, typeof(Customer))]
    [InlineData(4, typeof(Customer))]
    [InlineData(6, typeof(LoyalCustomer))]
    [InlineData(10, typeof(LoyalCustomer))]
    public void Create_ReturnsExpected(int yearsAsCustomer, Type expectedType)
    {
        var customer = CustomerFactory.Create("Test", yearsAsCustomer);
        Assert.IsType(expectedType, customer);
    }
}
