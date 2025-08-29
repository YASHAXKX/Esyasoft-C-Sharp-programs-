using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        List<List<int>> meterReadings = new List<List<int>>
        {
            new List<int>{10, 20, 30},  // Day 1
            new List<int>{11, 21, 31},  // Day 2
            new List<int>{12, 22, 32},  // Day 3
            new List<int>{13, 23, 33},  // Day 4
            new List<int>{14, 24, 34},  // Day 5
            new List<int>{15, 25, 35},  // Day 6
            new List<int>{16, 26, 36}   // Day 7
        };

        Console.WriteLine("1) Night Reading of Day 3: " + meterReadings[2][2]);
        Console.WriteLine();

        
        Dictionary<string, Dictionary<string, List<int>>> areaReadings = new Dictionary<string, Dictionary<string, List<int>>>
        {
            { "Area1", new Dictionary<string, List<int>> {
                { "House1", new List<int>{100, 200, 300, 400, 500, 600, 700} },
                { "House2", new List<int>{110, 210, 310, 410, 510, 610, 710} }
            }},
            { "Area2", new Dictionary<string, List<int>> {
                { "House3", new List<int>{120, 220, 320, 420, 520, 620, 720} }
            }}
        };

        Console.WriteLine("2) Readings of House1 in Area1:");
        foreach (var reading in areaReadings["Area1"]["House1"])
        {
            Console.Write(reading + " ");
        }
        Console.WriteLine("\n");

        
        Dictionary<string, List<string>> areaMeters = new Dictionary<string, List<string>>
        {
            { "Area1", new List<string>{ "Meter1", "Meter2", "Meter3" } },
            { "Area2", new List<string>{ "Meter4", "Meter5" } }
        };

        Console.WriteLine("3) Meters in Area1:");
        foreach (var meter in areaMeters["Area1"])
        {
            Console.WriteLine(meter);
        }
        Console.WriteLine();

        
        List<Dictionary<string, string>> complaints = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string>{{"HouseNum", "101"},{"Issue","Power Cut"},{"Date","2025-08-20"}},
            new Dictionary<string, string>{{"MeterNum", "M202"},{"Issue","Meter Fault"},{"Date","2025-08-22"}},
            new Dictionary<string, string>{{"HouseNum", "102"},{"Issue","Voltage Fluctuation"},{"Date","2025-08-25"}}
        };

        Console.WriteLine("4) Complaints List:");
        foreach (var complaint in complaints)
        {
            foreach (var kv in complaint)
            {
                Console.Write($"{kv.Key}: {kv.Value}, ");
            }
            Console.WriteLine();
        }
    }
}
