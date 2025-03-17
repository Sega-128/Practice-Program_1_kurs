using System;

public delegate int Operation(int a, int b);

class Program
{
    static int Add(int a, int b) => a + b;
    static int Multiply(int a, int b) => a * b;

    static void Calculate(int x, int y, Operation operation)
    {
        Console.WriteLine($"Результат: {operation(x, y)}");
    }

    static void Main()
    {
        Calculate(5, 3, Add);       
        Calculate(5, 3, Multiply);
    }
}
