using System;

namespace Testing;

public class Customer
{
    public string? Name { get; }
    public int YearsAsCustomer { get; }

    public Customer(string name, int yearsAsCustomer)
    {
        Name = name;
        YearsAsCustomer = yearsAsCustomer;
    }
}

public class LoyalCustomer : Customer
{
    public LoyalCustomer(string name, int yearsAsCustomer) : base(name, yearsAsCustomer)
    {
    }
}
