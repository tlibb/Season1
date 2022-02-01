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

        //greeting.GreetingWriter.MyColor = ConsoleColor.DarkCyan; (this does not work) Question: can we change the color from the main?
        //answer: yes, create the greetingwriter first and change its color as a property, then give it to the greeting object!
        //For example: julGreeting got the existing greetingWriter where we changed the color from default red to blue instead

        greeting.WriteMessage();

        var julGreeting = new ChristmasGreeting
        {
            Message = "Merry Christmas!",
            TimeStamp = DateTime.Now,
            GreetingWriter = greetingWriter,
        };

        julGreeting.WriteMessage();

        var newyearGreeting = new NewyearGreeting
        { 
            Message = "Happy NewYear!",
            TimeStamp = DateTime.Now,
            GreetingWriter = new ColorGreetingWriter(),
        };

        newyearGreeting.WriteMessage();

    }

}