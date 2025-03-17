using System;

public delegate void EventHandler(string message); 

class EventSource
{
    public event EventHandler? OnChange; 

    public void TriggerEvent(string message) 
    {
        OnChange?.Invoke(message);
    }
}

class Program
{
    static void ShowMessage(string msg) => Console.WriteLine($"Отримано повідомлення: {msg}"); 

    static void Main()
    {
        EventSource source = new EventSource();

        source.OnChange += ShowMessage;

        source.TriggerEvent("Привіт!"); 

        source.OnChange -= ShowMessage; 
    }
}
