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

    public void Write(IEnumerable<Greeting> greetings)
    {
        foreach (Greeting g in greetings)
        {
            Console.WriteLine(g.Message);
            Console.WriteLine();
        }
                
    }
}
