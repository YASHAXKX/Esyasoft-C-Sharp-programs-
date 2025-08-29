using System;
using System.Collections.Generic;

namespace SmartMeterSystem
{
    // 1. Enum
    public enum MeterStatus { Active, Inactive, Fault }

    // 2. Struct
    public struct Reading
    {
        public DateTime Date;
        public int Units;

        public Reading(DateTime date, int units)
        {
            Date = date;
            Units = units;
        }
    }

    // 3. Abstract class
    public abstract class Notifier
    {
        public abstract void SendMessage(string msg);
    }

    public class SmsNotifier : Notifier
    {
        private string phone;
        public SmsNotifier(string phone) => this.phone = phone;

        public override void SendMessage(string msg)
        {
            Console.WriteLine($" SMS to {phone}: {msg}");
        }
    }

    public class EmailNotifier : Notifier
    {
        private string email;
        public EmailNotifier(string email) => this.email = email;

        public override void SendMessage(string msg)
        {
            Console.WriteLine($" Email to {email}: {msg}");
        }
    }

    // 6. Static Class
    public static class Tariff
    {
        public static decimal RatePerUnit = 5.0m;
    }

    // 7. Sealed Class
    public sealed class BillCalculator
    {
        public static decimal CalculateBill(List<Reading> readings)
        {
            int totalUnits = 0;
            foreach (var r in readings)
                totalUnits += r.Units;

            return totalUnits * Tariff.RatePerUnit;
        }
    }

    // 8. Partial Class simulated inside one file
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
    }

    public partial class Customer
    {
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public Notifier GetNotifier()
        {
            // 5. Nullable with ?? fallback
            return (Email != null)
                ? new EmailNotifier(Email)
                : new SmsNotifier(Phone ?? "Unknown");
        }
    }

    // 9. Nested Class inside Meter
    public class Meter
    {
        public int MeterId { get; set; }
        public MeterStatus Status { get; set; }

        public class ReadingHistory
        {
            public List<Reading> Readings { get; private set; } = new List<Reading>();

            // 4. Event when new reading is added
            public event Action<Reading>? OnNewReading;

            public void AddReading(Reading r)
            {
                Readings.Add(r);
                OnNewReading?.Invoke(r);
            }
        }
    }

    // -------- MAIN PROGRAM --------
    class Program
    {
        static void Main()
        {
            // • Create a customer with only phone
            Customer cust = new Customer { CustomerId = 1, Name = "Alice", Phone = "9876543210" };
            // (Try with only Email: new Customer { Name = "Bob", Email = "bob@example.com" })

            // • Create a meter
            Meter meter = new Meter { MeterId = 101, Status = MeterStatus.Active };
            Meter.ReadingHistory history = new Meter.ReadingHistory();

            // • Trigger event that notifies customer
            Notifier notifier = cust.GetNotifier();
            history.OnNewReading += (reading) =>
            {
                notifier.SendMessage($"New Reading: {reading.Units} units on {reading.Date.ToShortDateString()}");
            };

            // • Add readings
            history.AddReading(new Reading(DateTime.Now.AddDays(-2), 50));
            history.AddReading(new Reading(DateTime.Now.AddDays(-1), 30));

            // • Generate bill
            decimal bill = BillCalculator.CalculateBill(history.Readings);
            Console.WriteLine($"\n Final Bill for {cust.Name}: Rs.{bill}");
        }
    }
}
