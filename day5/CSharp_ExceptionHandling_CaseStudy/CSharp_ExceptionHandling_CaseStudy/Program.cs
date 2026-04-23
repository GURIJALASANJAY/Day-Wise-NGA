using System;

// ================= CUSTOM EXCEPTIONS =================
public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}

public class InvalidAmountException : Exception
{
    public InvalidAmountException(string message) : base(message) { }
}

// ================= BANK ACCOUNT CLASS =================
public class BankAccount
{
    public string AccountHolderName { get; set; }
    public double Balance { get; private set; }

    private const double MIN_BALANCE = 1000;

    // Constructor
    public BankAccount(string name, double initialBalance)
    {
        AccountHolderName = name;

        if (initialBalance < MIN_BALANCE)
            throw new InvalidAmountException("Initial balance must be at least ₹1000");

        Balance = initialBalance;
    }

    // Deposit Method
    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new InvalidAmountException("Deposit amount must be greater than 0");

        Balance += amount;
        Console.WriteLine($"₹{amount} deposited successfully.");
    }

    // Withdraw Method
    public void Withdraw(double amount)
    {
        if (amount > Balance)
            throw new InsufficientBalanceException("Withdrawal exceeds available balance");

        if (Balance - amount < MIN_BALANCE)
            throw new InsufficientBalanceException("Minimum balance ₹1000 must be maintained");

        Balance -= amount;
        Console.WriteLine($"₹{amount} withdrawn successfully.");
    }

    // Check Balance
    public void CheckBalance()
    {
        Console.WriteLine($"Current Balance: ₹{Balance}");
    }
}

// ================= MAIN PROGRAM =================
class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter Account Holder Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Initial Balance: ");
            double initialBalance = double.Parse(Console.ReadLine());

            BankAccount account = new BankAccount(name, initialBalance);

            while (true)
            {
                Console.WriteLine("\n===== BANK MENU =====");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter deposit amount: ");
                            double deposit = double.Parse(Console.ReadLine());
                            account.Deposit(deposit);
                            break;

                        case 2:
                            Console.Write("Enter withdrawal amount: ");
                            double withdraw = double.Parse(Console.ReadLine());
                            account.Withdraw(withdraw);
                            break;

                        case 3:
                            account.CheckBalance();
                            break;

                        case 4:
                            return;

                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                catch (InvalidAmountException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (InsufficientBalanceException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input format!");
                }
                finally
                {
                    Console.WriteLine("Operation completed.\n");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fatal Error: " + ex.Message);
        }
    }
}