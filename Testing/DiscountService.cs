using System;

namespace Testing;

public class DiscountService
{
    public int GetDiscountPercentage(int age, int yearsAsCustomer)
    {
        if (age < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(age), "La edad no puede ser menor a 0");
        }

        if (yearsAsCustomer < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(yearsAsCustomer), "Los años no pueden ser menor a 0");
        }

        var baseDiscount = age switch
        {
            < 18 => 20,
            >= 18 and < 25 => 10,
            >= 25 and < 65 => 0,
            _ => 15
        };

        if (yearsAsCustomer >= 5)
        {
            baseDiscount += 5;
        }

        return baseDiscount;
    }
}
