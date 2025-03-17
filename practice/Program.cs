using System;

public delegate int Calculate();

class Program
{
    static int GetTen() => 10;
    static int GetTwenty() => 20;

    static void Main()
    {
        Calculate calc = GetTen;
        calc += GetTwenty;

        int result = calc(); 
        Console.WriteLine(result);
    }
}
