using System;

// Step 1: Order Class
public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public double Amount { get; set; }
}

// Step 2: Delegate + Publisher
public class OrderProcessor
{
    // Delegate
    public delegate void OrderPlacedHandler(Order order);

    // Event
    public event OrderPlacedHandler OnOrderPlaced;

    // Method to place order
    public void PlaceOrder(Order order)
    {
        Console.WriteLine("Order Placed: " + order.OrderId);

        // Trigger event (notify subscribers)
        OnOrderPlaced?.Invoke(order);
    }
}

// Step 3: Subscriber - Email Service
public class EmailService
{
    public void SendEmail(Order order)
    {
        Console.WriteLine("Email sent to customer");
    }
}

// Step 4: Subscriber - SMS Service
public class SMSService
{
    public void SendSMS(Order order)
    {
        Console.WriteLine("SMS sent to customer");
    }
}

// Step 5: Subscriber - Logger Service
public class LoggerService
{
    public void LogOrder(Order order)
    {
        Console.WriteLine("Order logged successfully");
    }
}

// Step 6: Main Program
class Program
{
    static void Main()
    {
        // Create publisher
        OrderProcessor processor = new OrderProcessor();

        // Create subscribers
        EmailService emailService = new EmailService();
        SMSService smsService = new SMSService();
        LoggerService loggerService = new LoggerService();

        // Subscribe to event
        processor.OnOrderPlaced += emailService.SendEmail;
        processor.OnOrderPlaced += smsService.SendSMS;
        processor.OnOrderPlaced += loggerService.LogOrder;

        // Take user input
        Order order = new Order();

        Console.Write("Enter Order ID: ");
        order.OrderId = int.Parse(Console.ReadLine());

        Console.Write("Enter Customer Name: ");
        order.CustomerName = Console.ReadLine();

        Console.Write("Enter Amount: ");
        order.Amount = double.Parse(Console.ReadLine());

        // Process order
        processor.PlaceOrder(order);

        // BONUS: Unsubscribe example (optional)
        // processor.OnOrderPlaced -= smsService.SendSMS;
    }
}