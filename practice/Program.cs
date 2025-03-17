using System;

public delegate void KeyPressedHandler(object sender, ConsoleKeyInfo keyInfo);

class KeyListener
{
    public event KeyPressedHandler? OnKeyPressed;

    public void StartListening()
    {
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true); 
            OnKeyPressed?.Invoke(this, keyInfo); 
        }
    }
}

class Program
{
    static void Main()
    {
        KeyListener listener = new KeyListener();

        listener.OnKeyPressed += (sender, keyInfo) =>
        {
            Console.WriteLine($"Ви натиснули: {keyInfo.Key}");

            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Програма завершена!");
                Environment.Exit(0);
            }
        };

        Console.WriteLine("Натисніть клавішу (Esc - вихід)...");

        listener.StartListening();
    }
}
