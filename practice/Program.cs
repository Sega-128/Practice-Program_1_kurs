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

        BankAccountClass secondAccount = new BankAccountClass(500);
        // переказати 300
        accountClass.Transfer();
        Console.WriteLine($"Клас (після переказу): {accountClass.Balance}");
        Console.WriteLine($"Другий рахунок (отримав переказ): {secondAccount.Balance}");

        BankAccountStruct secondAccountStruct = new BankAccountStruct(500);
        // переказати 300 
        accountStruct.Transfer();
        Console.WriteLine($"Структура (після переказу): {accountStruct.Balance}");
        Console.WriteLine($"Другий рахунок структури (отримав переказ): {secondAccountStruct.Balance}");

        AccountHelper.PrintBalance(accountClass);
        AccountHelper.PrintBalance(accountStruct);
    }
}