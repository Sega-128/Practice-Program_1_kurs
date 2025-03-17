using System;
using System.Text;


class OrderProcessor
{
    public void ProcessOrder(string restaurant, double price)
    {
        double total;

        if (restaurant == "McBurger")
        {
            total = price * 0.9; 
            Console.WriteLine($"McBurger: Вартість замовлення після знижки: {total} грн");
        }
        else if (restaurant == "PizzaHouse")
        {
            total = price + 20; 
            Console.WriteLine($"PizzaHouse: Вартість замовлення з доставкою: {total} грн");
        }
        else
        {
            total = price; 
            Console.WriteLine($"Звичайний ресторан: Вартість замовлення: {total} грн");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        OrderProcessor processor = new OrderProcessor();
        processor.ProcessOrder("McBurger", 200);
        processor.ProcessOrder("PizzaHouse", 150);
        processor.ProcessOrder("SushiBar", 300);
    }
}
