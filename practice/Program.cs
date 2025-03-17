using System;

public delegate void Operation(int a, int b);

class Program
{
    static void PrintSum(int a, int b) => Console.WriteLine(a + b);

    static void Main()
    {
        Operation op = PrintSum;
        Console.WriteLine($"Результат: {op(5, 3)}");
    }
}