using System;

namespace Testing.Tests;

public class DiscountServiceTests
{
    [Fact]
    public void GetDiscountPercentage_TeenCustomer_Returns20Percent()
    {
        var service = new DiscountService();
        var discount = service.GetDiscountPercentage(16, 1);
        Assert.Equal(20, discount);
    }

    [Fact]
    public void GetDiscountPercentage_AdultCustomerWithFewYears_Returns0Percent()
    {
        var service = new DiscountService();
        var discount = service.GetDiscountPercentage(age: 50, yearsAsCustomer: 1);
        Assert.Equal(0, discount);
    }

    [Fact]
    public void GetDiscountPercentage_SeniorCustomerWithFewYears_Returns15Percent()
    {
        var service = new DiscountService();
        var discount = service.GetDiscountPercentage(age: 66, yearsAsCustomer: 1);
        Assert.Equal(15, discount);
    }

    [Theory]
    [InlineData(16, 5, 25)]
    [InlineData(20, 5, 15)]
    [InlineData(30, 6, 5)]
    [InlineData(80, 6, 20)]
    public void GetDiscountPercentage_LoyalCustomers_GetExtra5Percent(int age, int yearsAsCustomer, int expectDiscount)
    {
        var service = new DiscountService();
        var discount = service.GetDiscountPercentage(age, yearsAsCustomer);
        Assert.Equal(expectDiscount, discount);
    }

    [Theory]
    [InlineData(10, 0)]
    [InlineData(20, 5)]
    [InlineData(30, 10)]
    [InlineData(80, 3)]
    public void GetDiscountPercentage_DiscountIsAlwaysWithinExpectedRange(int age, int yearsAsCustomer)
    {
        var service = new DiscountService();
        var discount = service.GetDiscountPercentage(age, yearsAsCustomer);
        Assert.InRange(discount, 0, 30);
    }

    [Fact]
    public void GetDiscountPercentage_NegativeAge_ThrowArgumentOutOfRangeException()
    {
        var service = new DiscountService();
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            service.GetDiscountPercentage(age: -10, yearsAsCustomer: 1);
        });
        Assert.Equal("age", exception.ParamName);
    }

    [Fact]
    public void GetDiscountPercentage_NegativeYearsAsCustomer_ThrowArgumentOutOfRangeException()
    {
        var service = new DiscountService();
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            service.GetDiscountPercentage(age: 10, yearsAsCustomer: -1);
        });
        Assert.Equal("yearsAsCustomer", exception.ParamName);
    }

    [Theory]
    [InlineData(17, 0, 20)]
    [InlineData(18, 0, 10)]
    [InlineData(24, 0, 10)]
    [InlineData(25, 0, 0)]
    [InlineData(64, 0, 0)]
    [InlineData(65, 0, 15)]
    public void GetDiscountPercentage_AgeBoundaries_ReturnsExpectedDiscount(int age, int yearsAsCustomer, int expectDiscount)
    {
        var service = new DiscountService();
        var discount = service.GetDiscountPercentage(age, yearsAsCustomer);
        Assert.Equal(expectDiscount, discount);
    }
}
