using System;

public class BankClass
{
    public string AccountNumber { get; set; }
    public string AccountHolderName { get; set; }
    public decimal Balance { get; private set; }
    private int Pincode { get; set; }

    public BankClass(string accountNumber, string accountHolderName, int pincode, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber;
        AccountHolderName = accountHolderName;
        Pincode = pincode;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposit successful. New balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }

    public void Withdraw(decimal amount, int enteredPincode)
    {
        if (enteredPincode != Pincode)
        {
            Console.WriteLine("Incorrect pincode. Transaction denied.");
            return;
        }

        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawal successful. New balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
        }
    }
}

class Program
{
    static void Main()
    {
        BankClass account = new BankClass("123456", "Ali Khan", 1234, 1000);

        account.Deposit(500);
        account.Withdraw(200, 1234);
        account.Withdraw(100, 9999);  // Incorrect pincode
    }
}

