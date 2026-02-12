using System;

namespace Testing;

public static class CustomerFactory
{
    public static Customer Create(string name, int yearsAsCustomer)
    {
        return yearsAsCustomer >= 5 ? new LoyalCustomer(name, yearsAsCustomer) : new Customer(name, yearsAsCustomer);
    }
}
