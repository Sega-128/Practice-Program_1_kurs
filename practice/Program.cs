using System;

public delegate void Notify();

class Program
{
    static void Method1() => Console.WriteLine("Method1 викликано!");
    static void Method2() => Console.WriteLine("Method2 викликано!");

    static void Main()
    {
        Notify notifier = Method1;
        notifier += Method2;

        Console.WriteLine("notifier call 1");
        notifier();

        notifier -= Method1;

        Console.WriteLine("notifier call 2");
        notifier();
    }
}
