using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Console.Write("Введіть тип палива (бензин/дизель/газ/електрика): ");
string fuelType = Console.ReadLine().ToLower();

double fuelPrice = 0;
if (fuelType == "бензин") fuelPrice = 56.91;
else if (fuelType == "дизель") fuelPrice = 55.30;
else if (fuelType == "газ") fuelPrice = 36.98;
else if (fuelType == "газ") fuelPrice = 6.50;
else
{
    Console.WriteLine("Невідомий тип палива.");
    return;
}

Console.Write("Введіть витрату (л/100 км або кВт⋅год/100 км для електро): ");
if (!double.TryParse(Console.ReadLine(), out double consumption) || consumption <= 0)
{
    Console.WriteLine("Некоректне значення витрати.");
    return;
}

Console.Write("Введіть пройдену відстань (км): ");
if (!double.TryParse(Console.ReadLine(), out double distance) || distance <= 0)
{
    Console.WriteLine("Некоректне значення відстані.");
    return;
}

double litersUsed = (distance / 100.0) * consumption; 
double totalCost =  litersUsed * fuelPrice;

Console.WriteLine($"Витрати на паливо: {totalCost:F2} грн.");

// part 2
Console.Write("Введіть кількість таких поїздок на місяць: ");
if (!int.TryParse(Console.ReadLine(), out int tripsPerMonth) || tripsPerMonth <= 0)
{
    Console.WriteLine("Некоректне значення.");
    return;
}

double monthlyCost = totalCost * tripsPerMonth;
double yearlyCost = monthlyCost * 12;

Console.WriteLine($"Місячні витрати: {monthlyCost:F2} грн.");
Console.WriteLine($"Річні витрати: {yearlyCost:F2} грн.");


// part 3
Console.Write("Оберіть валюту (грн/usd/eur/pln): ");
string currency = Console.ReadLine().ToLower();

double currencyRate = 1;

if (currency == "usd") currencyRate = 39.2;
else if (currency == "eur") currencyRate = 42.5;
else if (currency == "pln") currencyRate = 9.3;
else Console.WriteLine("Використовується гривня.");

double convertedCost = totalCost / currencyRate;
double convertedCostMonth = monthlyCost / currencyRate;
double convertedCostYearly = yearlyCost / currencyRate;
Console.WriteLine($"Витрати у {currency.ToUpper()}: {convertedCost:F2}");
Console.WriteLine($"Місячні витрати у {currency.ToUpper()}:: {convertedCostMonth:F2} грн.");
Console.WriteLine($"Річні витрати у {currency.ToUpper()}:: {convertedCostYearly:F2} грн.");