using System;

class SmartMeterAccount
{
    private decimal balance;   

    
    public void Recharge(decimal amount)
    {
        balance += amount;
        Console.WriteLine($"Balance after recharge: {balance}");
    }

    
    public void Consume(decimal amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Balance after consumption: {balance}");
        }
        else
        {
            Console.WriteLine("Insufficient balance");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SmartMeterAccount account = new SmartMeterAccount();

        
        account.Recharge(500);
        account.Consume(200);
        account.Consume(400);
    }
}
