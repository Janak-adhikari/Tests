using System;
using System.Collections.Generic;

class Customer
{
    public string FirstName { get; }
    public DateTime DateOfBirth { get; }
    public string AccountNumber { get; }
    public double Balance { get; private set; }
    public List<Transaction> TransactionLog { get; }

    public Customer(string firstName, DateTime dateOfBirth, string accountNumber)
    {
        FirstName = firstName;
        DateOfBirth = dateOfBirth;
        AccountNumber = accountNumber;
        Balance = 0;
        TransactionLog = new List<Transaction>();
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    public bool Withdraw(double amount, string remark)
    {
        if (amount > 0 && amount <= Balance && !string.IsNullOrEmpty(remark))
        {
            Balance -= amount;
            return true;
        }
        return false;
    }

    public void LogTransaction(double amount, string remarks)
    {
        TransactionLog.Add(new Transaction(amount, remarks));
    }
}
