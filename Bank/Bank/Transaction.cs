using System;

class Transaction
{
    public DateTime DateTime { get; }
    public double Amount { get; }
    public string Remarks { get; }

    public Transaction(double amount, string remarks)
    {
        DateTime = DateTime.Now;
        Amount = amount;
        Remarks = remarks;
    }
}
