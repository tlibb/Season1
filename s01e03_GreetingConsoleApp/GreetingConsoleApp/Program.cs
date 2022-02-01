namespace GreetingConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine("Hello World!");

        var greeting2 = new Greeting();
        
        greeting2.Message = "Welcome!";
        Console.WriteLine(greeting2.GetMessage());
        Console.WriteLine();

        var greetingWriter = new ColorGreetingWriter();

        greetingWriter.MyColor = ConsoleColor.DarkCyan;
        greetingWriter.Write("test");

        var greeting = new Greeting
        {
            Message = "Hello!",
            To = "Upskillers",
            From = "Tine",
            GreetingWriter = new BlackWhiteGreetingWriter(),
        };

        greeting.WriteMessage();

        var julGreeting = new ChristmasGreeting
        {
            Message = "Merry Christmas!",
            TimeStamp = DateTime.Now,
          //  GreetingWriter = new ColorGreetingWriter(),
        };

        try 
        { 
            julGreeting.WriteMessage();
        }
        catch (Exception ex)
        { 
            Console.WriteLine($"Oops an error occured: {ex.Message}");
        }
            
            

        var newyearGreeting = new NewyearGreeting
        { 
            Message = "Happy NewYear!",
            TimeStamp = DateTime.Now,
            GreetingWriter = new ColorGreetingWriter(),
        };

        newyearGreeting.WriteMessage();

    }

}