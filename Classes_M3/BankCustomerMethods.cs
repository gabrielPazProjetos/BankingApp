using System;

namespace Classes_M3;

public partial class BankCustomer
{
    public string ReturnFullName()
    {
        return $"{FirstName} {LastName}";
    }

    public void UpdateName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string DisplayCustomerInfo()
    {
        return $"Customer ID: {CustomerId}, Name: {ReturnFullName()}";
    }
}
