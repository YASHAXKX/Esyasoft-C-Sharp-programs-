using System;

class SmartMeterStats
{
    // Enum for days of week
    enum Days { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    static void Main(string[] args)
    {
        // Input array (7 days)
        int[] units = new int[7];

        Console.WriteLine("Enter units for 7 days (Mon-Sun):");
        for (int i = 0; i < 7; i++)
        {
            units[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Calculate total
        int total = 0;
        for (int i = 0; i < 7; i++)
        {
            total += units[i];
        }

        // Calculate average
        double average = (double)total / 7;

        // Find highest consumption
        int maxUnits = units[0];
        int maxDayIndex = 0;
        for (int i = 1; i < 7; i++)
        {
            if (units[i] > maxUnits)
            {
                maxUnits = units[i];
                maxDayIndex = i;
            }
        }

        // Output
        Console.WriteLine($"\nTotal units: {total}");
        Console.WriteLine($"Average units/day: {average:F2}");
        Console.WriteLine($"Highest consumption: {((Days)maxDayIndex)} ({maxUnits} units)");
    }
}
