using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();

        Console.WriteLine("Welcome to the Bank!");

        while (true)
        {
            Console.WriteLine("Are you a (1) New Customer or (2) Existing Customer? (Enter 1 or 2)");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 1)
                {
                    // New Customer
                    Console.Write("Enter your First Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter your Date of Birth (DD/MM/YYYY): ");
                    DateTime dob;
                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob))
                    {
                        string accountNumber = bank.CreateAccount(firstName, dob);
                        Console.WriteLine($"Your new account number: {accountNumber}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Date of Birth format.");
                    }
                }
                else if (choice == 2)
                {
                    // Existing Customer
                    Console.Write("Enter your Account Number: ");
                    string accountNumber = Console.ReadLine();

                    Customer customer = bank.GetCustomer(accountNumber);

                    if (customer != null)
                    {
                        Console.WriteLine($"Welcome, {customer.FirstName}!");

                        while (true)
                        {
                            Console.WriteLine("Choose an action: (1) Deposit, (2) Withdraw, (3) Check Balance, (4) View Transactions, (5) Exit");
                            if (int.TryParse(Console.ReadLine(), out int actionChoice))
                            {
                                if (actionChoice == 1)
                                {
                                    Console.Write("Enter the deposit amount: ");
                                    if (double.TryParse(Console.ReadLine(), out double amount))
                                    {
                                        customer.Deposit(amount);
                                        Console.WriteLine("Deposit successful.");

                                        // Log the transaction
                                        string depositRemark = "Deposit";
                                        customer.LogTransaction(amount, depositRemark);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid amount.");
                                    }
                                }
                                else if (actionChoice == 2)
                                {
                                    Console.Write("Enter the withdrawal amount: ");
                                    if (double.TryParse(Console.ReadLine(), out double amount))
                                    {
                                        Console.Write("Enter your Date of Birth for verification (DD/MM/YYYY): ");
                                        DateTime dob;
                                        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob) && dob == customer.DateOfBirth)
                                        {
                                            Console.Write("Enter a remark for the withdrawal: ");
                                            string remark = Console.ReadLine();
                                            bool success = customer.Withdraw(amount, remark);
                                            if (success)
                                            {
                                                Console.WriteLine("Withdrawal successful.");

                                                // Log the transaction
                                                customer.LogTransaction(-amount, remark);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Insufficient balance or invalid remark.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Date of Birth verification failed.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid amount.");
                                    }
                                }
                                else if (actionChoice == 3)
                                {
                                    Console.WriteLine($"Current Balance: {customer.Balance:C}");
                                }
                                else if (actionChoice == 4)
                                {
                                    Console.WriteLine("Transaction Log:");
                                    if (customer.TransactionLog.Count == 0)
                                    {
                                        Console.WriteLine("There haven't been any transactions yet.");
                                    }
                                    else
                                    {
                                        foreach (Transaction transaction in customer.TransactionLog)
                                        {
                                            Console.WriteLine($"{transaction.DateTime} - {transaction.Remarks}: {transaction.Amount:C}");
                                        }
                                    }
                                }

                                else if (actionChoice == 5)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Account Number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Enter 1 or 2.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Enter 1 or 2.");
            }
        }
    }
}
