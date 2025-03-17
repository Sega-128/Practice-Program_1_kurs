using System;

public delegate int Operation(int a, int b);
// public delegate double OperationD(double a, double b);

//class Example {
//    public delegate int Operation(int a, int b);
//}

class Program
{
    //public delegate double Operation(double a, double b);
    static int Add(int a, int b) => a + b;
    static int Multiply(int a, int b) => a * b;
    //static double MultiplyD(double a, double b) => a * b;

    static void Main()
    {
        // Error
        //public delegate int Operation(int a, int b);

        // example global scope
        //global::Operation op;
        //op = Add; 

        // example class delegate
        //Example.Operation op;

        //  Func<int, int, int> operation;

        Operation op;
        op = Add;     
        Console.WriteLine(op(5, 3));

        op = Multiply; 
        Console.WriteLine(op(5, 3));

        //OperationD opd;

        //opd = MultiplyD;
        //Console.WriteLine(opd(5.5, 3.5));

    }
}
