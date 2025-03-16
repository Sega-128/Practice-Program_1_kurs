using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        var fuelInput = new FuelInput();
        string fuelType = fuelInput.GetFuelType();
        double fuelPrice = fuelInput.GetFuelPrice(fuelType);
        if (fuelPrice == 0) return;

        var userInput = new UserInput();
        double consumption = userInput.GetDoubleInput("Введіть витрату (л/100 км або кВт⋅год/100 км для електро): ");
        double distance = userInput.GetDoubleInput("Введіть пройдену відстань (км): ");

        var fuelCalculator = new FuelCalculator(consumption, distance, fuelPrice);
        double totalCost = fuelCalculator.CalculateFuelCost();
        Console.WriteLine($"Витрати на паливо: {totalCost:F2} грн.");

        int tripsPerMonth = userInput.GetIntInput("Введіть кількість таких поїздок на місяць: ");
        double monthlyCost = totalCost * tripsPerMonth;
        double yearlyCost = monthlyCost * 12;

        Console.WriteLine($"Місячні витрати: {monthlyCost:F2} грн.");
        Console.WriteLine($"Річні витрати: {yearlyCost:F2} грн.");

        var currencyConverter = new CurrencyConverter();
        string currency = currencyConverter.GetCurrency();
        double currencyRate = currencyConverter.GetCurrencyRate(currency);

        currencyConverter.DisplayConvertedCosts(totalCost, monthlyCost, yearlyCost, currency, currencyRate);


        Console.WriteLine("Вихід з Main() - об'єкт FuelCalculator ще існує!");

        //Console.WriteLine("Примусово викликаємо GC...");
        //GC.Collect();
        //GC.WaitForPendingFinalizers();

        //Console.WriteLine("Програма завершена.");
    }
}

class FuelInput
{
    public FuelInput() { }
    public string GetFuelType()
    {
        Console.Write("Введіть тип палива (бензин/дизель/газ/електрика): ");
        return Console.ReadLine().ToLower();
    }

    public double GetFuelPrice(string fuelType)
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

    private double InvalidFuel()
    {
        Console.WriteLine("Невідомий тип палива.");
        return 0;
    }
}

class UserInput
{
    public UserInput() { }

    public double GetDoubleInput(string message)
    {
        Console.Write(message);
        if (!double.TryParse(Console.ReadLine(), out double value) || value <= 0)
        {
            Console.WriteLine("Некоректне значення.");
            Environment.Exit(0);
        }
        return value;
    }

    public int GetIntInput(string message)
    {
        Console.Write(message);
        if (!int.TryParse(Console.ReadLine(), out int value) || value <= 0)
        {
            Console.WriteLine("Некоректне значення.");
            Environment.Exit(0);
        }
        return value;
    }
}

class FuelCalculator
{
    private double Consumption { get; }
    private double Distance { get; }
    private double FuelPrice { get; }

    public FuelCalculator(double consumption, double distance, double fuelPrice)
    {
        Consumption = consumption;
        Distance = distance;
        FuelPrice = fuelPrice;
    }

    public double CalculateFuelCost()
    {
        return (Distance / 100.0) * Consumption * FuelPrice;
    }

    // for example!!!
    ~FuelCalculator()
    {
        Console.WriteLine("Об'єкт FuelCalculator знищено");
    }
}

class CurrencyConverter
{
    public CurrencyConverter() { }

    public string GetCurrency()
    {
        Console.Write("Оберіть валюту (грн/usd/eur/pln): ");
        return Console.ReadLine().ToLower();
    }

    public double GetCurrencyRate(string currency)
    {
        return currency switch
        {
            "usd" => 39.2,
            "eur" => 42.5,
            "pln" => 9.3,
            _ => 1
        };
    }

    public void DisplayConvertedCosts(double totalCost, double monthlyCost, double yearlyCost, string currency, double rate)
    {
        Console.WriteLine($"Витрати у {currency.ToUpper()}: {totalCost / rate:F2}");
        Console.WriteLine($"Місячні витрати у {currency.ToUpper()}: {monthlyCost / rate:F2}");
        Console.WriteLine($"Річні витрати у {currency.ToUpper()}: {yearlyCost / rate:F2}");
    }
}
