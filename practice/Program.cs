using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        string fuelType = FuelCalculator.GetFuelType();
        double fuelPrice = FuelCalculator.GetFuelPrice(fuelType);
        if (fuelPrice == 0) return;

        double consumption = FuelCalculator.GetDoubleInput("Введіть витрату (л/100 км або кВт⋅год/100 км для електро): ");
        double distance = FuelCalculator.GetDoubleInput("Введіть пройдену відстань (км): ");

        double totalCost = FuelCalculator.CalculateFuelCost(consumption, distance, fuelPrice);
        Console.WriteLine($"Витрати на паливо: {totalCost:F2} грн.");

        int tripsPerMonth = FuelCalculator.GetIntInput("Введіть кількість таких поїздок на місяць: ");
        double monthlyCost = totalCost * tripsPerMonth;
        double yearlyCost = monthlyCost * 12;

        Console.WriteLine($"Місячні витрати: {monthlyCost:F2} грн.");
        Console.WriteLine($"Річні витрати: {yearlyCost:F2} грн.");

        string currency = FuelCalculator.GetCurrency();
        double currencyRate = FuelCalculator.GetCurrencyRate(currency);

        FuelCalculator.DisplayConvertedCosts(totalCost, monthlyCost, yearlyCost, currency, currencyRate);
    }
}

class FuelCalculator {
    public static string GetFuelType()
    {
        Console.Write("Введіть тип палива (бензин/дизель/газ/електрика): ");
        return Console.ReadLine().ToLower();
    }

    public static double GetFuelPrice(string fuelType)
    {
        return fuelType switch
        {
            "бензин" => 56.91,
            "дизель" => 55.30,
            "газ" => 36.98,
            "електрика" => 6.50,
            _ => InvalidFuel()
        };
    }

    public static double InvalidFuel()
    {
        Console.WriteLine("Невідомий тип палива.");
        return 0;
    }

    public static double GetDoubleInput(string message)
    {
        Console.Write(message);
        if (!double.TryParse(Console.ReadLine(), out double value) || value <= 0)
        {
            Console.WriteLine("Некоректне значення.");
            Environment.Exit(0);
        }
        return value;
    }

    public static int GetIntInput(string message)
    {
        Console.Write(message);
        if (!int.TryParse(Console.ReadLine(), out int value) || value <= 0)
        {
            Console.WriteLine("Некоректне значення.");
            Environment.Exit(0);
        }
        return value;
    }

    public static double CalculateFuelCost(double consumption, double distance, double fuelPrice)
    {
        return (distance / 100.0) * consumption * fuelPrice;
    }

    public static string GetCurrency()
    {
        Console.Write("Оберіть валюту (грн/usd/eur/pln): ");
        return Console.ReadLine().ToLower();
    }

    public static double GetCurrencyRate(string currency)
    {
        return currency switch
        {
            "usd" => 39.2,
            "eur" => 42.5,
            "pln" => 9.3,
            _ => 1
        };
    }

    public static void DisplayConvertedCosts(double totalCost, double monthlyCost, double yearlyCost, string currency, double rate)
    {
        Console.WriteLine($"Витрати у {currency.ToUpper()}: {totalCost / rate:F2}");
        Console.WriteLine($"Місячні витрати у {currency.ToUpper()}: {monthlyCost / rate:F2}");
        Console.WriteLine($"Річні витрати у {currency.ToUpper()}: {yearlyCost / rate:F2}");
    }
}
