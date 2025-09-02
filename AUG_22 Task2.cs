using System;

class Customer
{
    // Properties
    public int CustomerID { get; set; }
    public string Name { get; set; }
    public int UnitsConsumed { get; set; }

    // Constructor
    public Customer(int customerID, string name, int unitsConsumed)
    {
        CustomerID = customerID;
        Name = name;
        UnitsConsumed = unitsConsumed;
    }

    // Method to show bill
    public void ShowBill()
    {
        int billAmount = UnitsConsumed * 5;
        Console.WriteLine($"Customer: {Name} (ID: {CustomerID})");
        Console.WriteLine($"Units Consumed: {UnitsConsumed}");
        Console.WriteLine($"Total Bill: ${billAmount}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Taking input
        Console.Write("Enter Customer ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Units Consumed: ");
        int units = Convert.ToInt32(Console.ReadLine());

        // Creating object
        Customer customer = new Customer(id, name, units);

        // Displaying bill
        customer.ShowBill();
    }
}
