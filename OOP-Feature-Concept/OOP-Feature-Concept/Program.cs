using System;

// Base class: Account
//NAME: SADIQ KABIRU
//DATE: 01ST NOVEMBER, 2025
//EMAIL:WEBEMAIL655@GMAIL.COM
public abstract class Account
{
    protected string accountNumber;
    protected decimal balance;

    public Account(string accountNumber, decimal initialBalance)
    {
        this.accountNumber = accountNumber;
        this.balance = initialBalance;
    }

    // Encapsulation: Properties to access and modify balance
    public decimal Balance
    {
        get { return balance; }
        protected set { balance = value; }
    }

    // Abstraction: Method to deposit money
    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited {amount}. New balance: {Balance}");
    }

    // Abstract method to calculate interest
    public abstract decimal CalculateInterest();
}

// Derived class: SavingsAccount
public class SavingsAccount : Account
{
    private decimal interestRate;

    public SavingsAccount(string accountNumber, decimal initialBalance, decimal interestRate)
        : base(accountNumber, initialBalance)
    {
        this.interestRate = interestRate;
    }

    // Polymorphism: Override CalculateInterest method
    public override decimal CalculateInterest()
    {
        decimal interest = Balance * interestRate / 100;
        Console.WriteLine($"Interest: {interest}");
        return interest;
    }
}

// Derived class: CurrentAccount
public class CurrentAccount : Account
{
    private decimal overdraftLimit;

    public CurrentAccount(string accountNumber, decimal initialBalance, decimal overdraftLimit)
        : base(accountNumber, initialBalance)
    {
        this.overdraftLimit = overdraftLimit;
    }

    // Polymorphism: Override CalculateInterest method
    public override decimal CalculateInterest()
    {
        // No interest for current accounts
        return 0;
    }

    // Additional method specific to CurrentAccount
    public void WithdrawOverdraft(decimal amount)
    {
        if (amount <= overdraftLimit)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn {amount}. New balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Insufficient overdraft limit.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create instances of SavingsAccount and CurrentAccount
        Account savingsAccount = new SavingsAccount("SAV123", 1000, 5);
        Account currentAccount = new CurrentAccount("CUR456", 500, 2000);

        // Deposit money into accounts
        savingsAccount.Deposit(500);
        currentAccount.Deposit(200);

        // Calculate interest for accounts
        savingsAccount.CalculateInterest();
        currentAccount.CalculateInterest();

        // Use specific method for CurrentAccount
        CurrentAccount current = (CurrentAccount)currentAccount;
        current.WithdrawOverdraft(1000);
    }
}