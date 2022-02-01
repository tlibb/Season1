namespace GreetingConsoleApp;

public class Program
{

    public static void ProcessGreeting(Greeting greeting)
    { 
        //Console.WriteLine(greeting.GetMessage());
        greeting.WriteMessage();
    }

    public static void ProcessGreetings(List<Greeting> greetings) 
    { 
        foreach (Greeting g in greetings)
        {
            //Console.WriteLine(g.GetMessage());
            g.WriteMessage();
        }
    }

    public static List<Greeting> GenerateGreetings(int count)
    {
        var ourGreetings = new List<Greeting>();

        for (int i = 0; i < count; i++)
        {
            var g = new Greeting();
            if (i%2 == 0)
            {
                g.Message = $"This is an odd greeting: {i}!";
                g.GreetingWriter = new BlackWhiteGreetingWriter();
            }
            else
            {
                g.Message = $"This is an even greeting: {i}!";
                g.GreetingWriter = new ColorGreetingWriter();
            }

            ourGreetings.Add(g);
        }
        return ourGreetings;
    }


    public static void Main(string[] args)
    {
        //Console.WriteLine("Hello World!");

        var greeting2 = new Greeting();
        
        greeting2.Message = "Welcome!";
        //Console.WriteLine(greeting2.GetMessage());
        //Console.WriteLine();

       
        var greeting = new Greeting
        {
            Message = "Hello!",
            To = "Upskillers",
            From = "Tine",
            GreetingWriter = new BlackWhiteGreetingWriter(),
        };

        //greeting.GreetingWriter.MyColor = ConsoleColor.DarkCyan; Question: can we change the color from the main?
        //greeting.WriteMessage();

        var julGreeting = new ChristmasGreeting
        {
            Message = "Merry Christmas!",
            TimeStamp = DateTime.Now,
            GreetingWriter = new ColorGreetingWriter(),
        };
            

        var newyearGreeting = new NewyearGreeting
        { 
            Message = "Happy NewYear!",
            TimeStamp = DateTime.Now,
            GreetingWriter = new ColorGreetingWriter(),
        };

        //newyearGreeting.WriteMessage();

        //var greetings = new List<Greeting>();

        //greetings.Add(greeting);
        //greetings.Add(greeting2);
        //greetings.Add(julGreeting);
        //greetings.Add(newyearGreeting);


        //ProcessGreetings(greetings);
        //ProcessGreeting(greeting);

        var myList = GenerateGreetings(1000);
        ProcessGreetings(myList);
    }

}