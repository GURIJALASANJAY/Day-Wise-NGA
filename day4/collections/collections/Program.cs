using System;
using System.Collections.Generic;

namespace OrderManagementSystem
{
    // Customer Entity
    class Client
    {
        public int ClientId { get; }
        public string ClientName { get; }

        public Client(int clientId, string clientName)
        {
            ClientId = clientId;
            ClientName = clientName;
        }
    }

    // Order Entity
    class Purchase
    {
        public int PurchaseId { get; }
        public int ClientRefId { get; }

        private string productType;
        private List<string> trackingHistory = new List<string>();

        public string ProductType
        {
            get { return productType; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    productType = value;
                else
                    Console.WriteLine("Invalid product type!");
            }
        }

        public Purchase(int purchaseId, int clientRefId, string productType)
        {
            PurchaseId = purchaseId;
            ClientRefId = clientRefId;
            ProductType = productType;
        }

        public void AddTrackingUpdate(string status)
        {
            trackingHistory.Add(status);
        }

        public void DisplayTrackingHistory()
        {
            foreach (var status in trackingHistory)
            {
                Console.WriteLine(" - " + status);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Collections with better names
            List<Purchase> purchaseList = new List<Purchase>();
            Dictionary<int, Client> clientDirectory = new Dictionary<int, Client>();
            HashSet<string> uniqueProductTypes = new HashSet<string>();
            Queue<Purchase> processingQueue = new Queue<Purchase>();

            // Add clients
            clientDirectory[1] = new Client(1, "Sanjay");
            clientDirectory[2] = new Client(2, "Sanju");

            // Create purchases
            Purchase p1 = new Purchase(201, 1, "Electronics");
            Purchase p2 = new Purchase(202, 2, "Clothing");

            purchaseList.Add(p1);
            purchaseList.Add(p2);

            // Add unique categories
            uniqueProductTypes.Add(p1.ProductType);
            uniqueProductTypes.Add(p2.ProductType);
            uniqueProductTypes.Add("Electronics"); // duplicate ignored

            // Add tracking updates
            p1.AddTrackingUpdate("Order Placed");
            p1.AddTrackingUpdate("Out for Delivery");

            p2.AddTrackingUpdate("Order Placed");

            // Add to processing queue
            processingQueue.Enqueue(p1);
            processingQueue.Enqueue(p2);

            Console.WriteLine("Updating Purchase 202");
            p2.ProductType = "Fashion";

            Console.WriteLine("Deleting Purchase 201");
            purchaseList.Remove(p1);

            Console.WriteLine("\nProcessing Queue:");
            while (processingQueue.Count > 0)
            {
                var currentPurchase = processingQueue.Dequeue();

                if (clientDirectory.TryGetValue(currentPurchase.ClientRefId, out Client client))
                {
                    Console.WriteLine($"Processing Purchase: {currentPurchase.PurchaseId}, Client: {client.ClientName}");
                }
            }

            Console.WriteLine("\nTracking History:");
            foreach (var purchase in purchaseList)
            {
                if (clientDirectory.TryGetValue(purchase.ClientRefId, out Client client))
                {
                    Console.WriteLine($"Purchase {purchase.PurchaseId} for {client.ClientName}:");
                    purchase.DisplayTrackingHistory();
                }
            }

            Console.WriteLine("\nUnique Product Types:");
            foreach (var type in uniqueProductTypes)
            {
                Console.WriteLine(type);
            }
        }
    }
}