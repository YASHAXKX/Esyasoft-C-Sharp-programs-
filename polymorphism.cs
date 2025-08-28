using System;

abstract class MeterReading
{
    public int Units { get; set; }

    public MeterReading(int units)
    {
        Units = units;
    }

    // Abstract method (must be implemented by derived classes)
    public abstract int CalculateBill();
}

class ResidentialReading : MeterReading
{
    public ResidentialReading(int units) : base(units) { }

    public override int CalculateBill()
    {
        return Units * 5;   // ₹5 per unit
    }
}

class CommercialReading : MeterReading
{
    public CommercialReading(int units) : base(units) { }

    public override int CalculateBill()
    {
        return Units * 8;   // ₹8 per unit
    }
}

class Program
{
    static void Main(string[] args)
    {
        MeterReading residential = new ResidentialReading(100);
        MeterReading commercial = new CommercialReading(100);

        Console.WriteLine($"Residential Bill = {residential.CalculateBill()}");
        Console.WriteLine($"Commercial Bill = {commercial.CalculateBill()}");
    }
}
