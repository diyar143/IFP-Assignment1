using System;

public enum DeliveryType
{
    Pickup,
    Courier,
    DoorToDoor
}

public enum DeliveryZone
{
    City,
    OutsideCity,
    Remote
}

class Program
{
    static decimal ApplyRule(decimal price, Func<decimal, decimal> rule) => rule(price);

    static decimal ApplyQuantityRule(decimal price, int items)
    {
        if (items >= 8) return price * 1.20m;
        if (items >= 4) return price * 1.10m;
        return price;
    }

    static decimal CalculateTotalPrice(decimal basePrice, int items, DeliveryType type, DeliveryZone zone, bool isExpress)
    {
        Func<decimal, decimal> applyType = p => type switch
        {
            DeliveryType.Pickup => p * 0.80m,
            DeliveryType.DoorToDoor => p * 1.15m,
            _ => p
        };

        Func<decimal, decimal> applyZone = p => zone == DeliveryZone.OutsideCity ? p * 1.25m : p;

        decimal price = basePrice;
        price = ApplyQuantityRule(price, items);
        price = ApplyRule(price, applyType);
        price = ApplyRule(price, applyZone);
        price = ApplyRule(price, p => isExpress ? p * 1.30m : p);

        return Math.Round(price, 2);
    }

    static void Main()
    {
        Console.Write("Enter Base Delivery Price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal basePrice) || basePrice < 0)
        {
            Console.WriteLine("Error: Invalid base price.");
            return;
        }

        Console.Write("Enter Number of Items: ");
        if (!int.TryParse(Console.ReadLine(), out int items) || items < 1)
        {
            Console.WriteLine("Error: Invalid number of items.");
            return;
        }

        Console.Write("Enter Delivery Type (Pickup, Courier, DoorToDoor): ");
        if (!Enum.TryParse(Console.ReadLine(), out DeliveryType deliveryType))
        {
            Console.WriteLine("Error: Invalid delivery type.");
            return;
        }

        Console.Write("Enter Delivery Zone (City, OutsideCity, Remote): ");
        if (!Enum.TryParse(Console.ReadLine(), out DeliveryZone deliveryZone))
        {
            Console.WriteLine("Error: Invalid delivery zone.");
            return;
        }

        Console.Write("Is Express Delivery? (true/false): ");
        if (!bool.TryParse(Console.ReadLine(), out bool isExpress))
        {
            Console.WriteLine("Error: Invalid express status.");
            return;
        }

        decimal finalPrice = CalculateTotalPrice(basePrice, items, deliveryType, deliveryZone, isExpress);
        Console.WriteLine($"Final Delivery Cost: {finalPrice}");
    }
}