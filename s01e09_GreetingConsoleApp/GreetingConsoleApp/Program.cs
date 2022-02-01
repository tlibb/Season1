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
            if (i % 2 == 0)
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

    public static void PrintTemplate()
    { 
        var ourTemplate = new GreetingTemplateRepository();

        foreach(KeyValuePair<int, Greeting> ele1 in ourTemplate.GreetingTemplates)
        {
            Console.WriteLine($"ID = {ele1.Key} - Greeting message = {ele1.Value.GetMessage()}");
        }

        Console.WriteLine("Choose a template ID:");

        var inputID = Console.ReadLine();
        
        int intID;
        var mybool = Int32.TryParse(inputID, out intID);
        if (mybool)
        { 
            try
            {
                Console.WriteLine(ourTemplate.GetGreetingTemplate(intID).GetMessage());
            }
            
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("The input is not a number");
        } 
        

           
    }

    public static void PrintTemplatesWithLinq()
    {
        var myTemplate = new GreetingTemplateRepository();

        //myTemplate.SaveGreetingTemplate(int 4, Greeting new ChristmasGreeting()) try this later

        int myLength = 17;
        string myString = "testing";

        var myCollection = myTemplate.GetGreetingTemplatesByLengthWithLinq(myLength);
        Console.WriteLine($"Messages >= {myLength} - LINQ");

        foreach (Greeting el in myCollection)
        {
            Console.WriteLine(el.GetMessage());
        }

        var myCollection2 = myTemplate.GetGreetingTemplatesByLengthWithLambda(myLength);
        Console.WriteLine($"Messages >= {myLength} - LAMBDA");

        foreach (Greeting el in myCollection2)
        {
            Console.WriteLine(el.GetMessage());
        }

        var myCollection3 = myTemplate.GetGreetingTemplatesByLengthWithForeach(myLength);
        Console.WriteLine($"Messages >= {myLength} - Foreach");

        foreach (Greeting el in myCollection3)
        {
            Console.WriteLine(el.GetMessage());
        }

        var myCollection4 = myTemplate.GetGreetingTemplatesBySearchStringWithLinq(myString);
        Console.WriteLine($"Messages containing '{myString}' - LINQ");

        foreach (Greeting el in myCollection4)
        {
            Console.WriteLine(el.GetMessage());
        }

        var myCollection5 = myTemplate.GetGreetingTemplatesBySearchStringWithLambda(myString);
        Console.WriteLine($"Messages containing '{myString}' - LAMBDA");

        foreach (Greeting el in myCollection5)
        {
            Console.WriteLine(el.GetMessage());
        }

        var myCollection6 = myTemplate.GetGreetingTemplatesBySearchStringWithForeach(myString);
        Console.WriteLine($"Messages containing '{myString}' - Foreach");

        foreach (Greeting el in myCollection6)
        {
            Console.WriteLine(el.GetMessage());
        }
    }


    public static void Main(string[] args)
    {

        var greeting = new Greeting
        {
            Message = "Hello!",
            To = "Upskillers",
            From = "Tine",
            GreetingWriter = new BlackWhiteGreetingWriter(),
        };

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

        var logWriting = new FileGreetingWriter();

        logWriting.Write("This is a test log message.");

        
        
    }



}