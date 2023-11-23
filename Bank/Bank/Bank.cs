using System;
using System.Collections.Generic;

class Bank
{
    private List<Customer> customers;

    public Bank()
    {
        customers = new List<Customer>();
    }

    public string CreateAccount(string firstName, DateTime dateOfBirth)
    {
        // Generate a unique 5-digit account number
        string accountNumber = GenerateUniqueAccountNumber();
        Customer customer = new Customer(firstName, dateOfBirth, accountNumber);
        customers.Add(customer);
        return accountNumber;
    }

    public Customer GetCustomer(string accountNumber)
    {
        return customers.Find(c => c.AccountNumber == accountNumber);
    }

    private string GenerateUniqueAccountNumber()
    {
        int maxAccountNumber = 99999; // The maximum 5-digit number
        int minAccountNumber = 10000; // The minimum 5-digit number

        Random random = new Random();
        int accountNumber = random.Next(minAccountNumber, maxAccountNumber);

        return accountNumber.ToString("D5");
    }
}
