namespace GreetingConsoleApp;


public class BlackWhiteGreetingWriter : IGreetingWriter
{
    public void Write(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine();
    }

    public void Write(Greeting greeting)
    {
        Console.WriteLine(greeting.Message);
        Console.WriteLine();
    }
}
