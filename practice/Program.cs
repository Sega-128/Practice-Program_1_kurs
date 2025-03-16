using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        BankAccountClass accountClass = new BankAccountClass(1000);
        BankAccountClass accountClassCopy = accountClass;

        BankAccountStruct accountStruct = new BankAccountStruct(1000);
        BankAccountStruct accountStructCopy = accountStruct;

        accountClass.Deposit(500);
        accountStruct.Deposit(500);

        Console.WriteLine($"Клас (оригінал): {accountClass.Balance}");
        Console.WriteLine($"Клас (копія): {accountClassCopy.Balance}");
        Console.WriteLine($"Структура (оригінал): {accountStruct.Balance}");
        Console.WriteLine($"Структура (копія): {accountStructCopy.Balance}");

        accountClass.Withdraw(200);
        accountStruct.Withdraw(200);

        Console.WriteLine($"Клас (оригінал): {accountClass.Balance}");
        Console.WriteLine($"Клас (копія): {accountClassCopy.Balance}");
        Console.WriteLine($"Структура (оригінал): {accountStruct.Balance}");
        Console.WriteLine($"Структура (копія): {accountStructCopy.Balance}");
    }
}

