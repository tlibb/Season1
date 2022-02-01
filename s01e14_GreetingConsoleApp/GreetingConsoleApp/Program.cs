using Microsoft.Extensions.Configuration;

namespace GreetingConsoleApp;

public class Program
{
    public static Settings settings;

    private static IGreetingWriter _greetingWriter;

    //this is the contstructor of Program
    static Program()
    {
        //IConfiguration config = new ConfigurationBuilder()
        //    .AddJsonFile("appsettings.json")                        //appsettings.json is our settings file
        //    //this does not seem very logical to me. Why set a XML file with json settings? Tried setting an xml file but AddXmlFile did not work
        //    .Build();

        //// Get values from the config given their key and their target type.
        //_settings = config.GetRequiredSection("Settings").Get<Settings>();      //Get the section named "Settings" in our settings file and deserialize it to an object named _settings of type Settings

        settings = InitializeSettings();

        if (settings.GreetingWriterClassName == "FileGreetingWriter")
        {
            _greetingWriter = new FileGreetingWriter();
        }
        else if (settings.GreetingWriterClassName == "ColorGreetingWriter")
        {
            _greetingWriter = new ColorGreetingWriter();
        }
        else if (settings.GreetingWriterClassName == "JsonGreetingWriter")
        {
            _greetingWriter = new JsonGreetingWriter();
        }
        else if (settings.GreetingWriterClassName == "XMLGreetingWriter")
        {
            _greetingWriter = new XMLGreetingWriter();
        }
        else
        {
            _greetingWriter = new BlackWhiteGreetingWriter();
        }

        //I don't get the question mark thingy yet!

        //if (_settings.GreetingWriterClassName?.Equals("FileGreetingWriter",StringComparison.InvariantCultureIgnoreCase) == true)
        //{

        //}
    }

    public static Settings InitializeSettings()
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")                        //appsettings.json is our settings file
            .Build();                                                       //this does not seem very logical to me. Why set a XML file with json settings? Tried setting an xml file but AddXmlFile did not work.Build();

        // Get values from the config given their key and their target type.
        return config.GetRequiredSection("Settings").Get<Settings>();
    }
    static void ProcessGreeting(Greeting greeting)
    { 
        //Console.WriteLine(greeting.GetMessage());
        //greeting.WriteMessage();
        _greetingWriter.Write(greeting);
    }

    public static void ProcessGreetings(List<Greeting> greetings) 
    { 
        foreach (Greeting g in greetings)
        {
            //Console.WriteLine(g.GetMessage());
            //g.WriteMessage();
            _greetingWriter.Write(g);
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
            }
            else
            {
                g.Message = $"This is an even greeting: {i}!";
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

        //var myGreeting = new Greeting();
        //myGreeting.Message = "blabla";

        //var myTemplate = new GreetingTemplateRepository();

        //var myIEnum = myTemplate.GetGreetingTemplatesByLengthWithLinq(0);

        var myListOfGreetings = GenerateGreetings(10);

        

        _greetingWriter.Write(myListOfGreetings);
        
        
    }



}