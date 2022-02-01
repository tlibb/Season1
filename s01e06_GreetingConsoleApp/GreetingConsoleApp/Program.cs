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

        Console.WriteLine("Press 1 if you want to print 1000 greetings. \n Press 2 to select a greeting from a Collection \n Press any other number to test the Template Colection");
        var wantBatch = Console.ReadLine();

        bool boolBatch = Int32.TryParse(wantBatch, out var intBatch);
        if (boolBatch)
        {
            if (intBatch == 1)
            {
                var myList = GenerateGreetings(1000);
                ProcessGreetings(myList);
            }
            else if (intBatch == 2)
            {
                PrintTemplate();
            }
            else
            {
                var greetings = new List<Greeting>();

                greetings.Add(greeting);
                greetings.Add(julGreeting);
                greetings.Add(newyearGreeting);


                ProcessGreetings(greetings);
                ProcessGreeting(greeting);



                var myTemplate = new GreetingTemplateRepository();
                Console.WriteLine(myTemplate.GetGreetingTemplate(2).GetMessage());

                var greeting4 = new Greeting
                {
                    Message = "My fourth dictionary greeting",
                };

                myTemplate.SaveGreetingTemplate(3, greeting4);
                try
                {
                    Console.WriteLine(myTemplate.GetGreetingTemplate(3).GetMessage());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"there was an error: {ex.Message}");
                }
                //Console.WriteLine(myTemplate.GetGreetingTemplate(5).GetMessage());
                try
                {
                    var overlapGreeting = new Greeting
                    {
                        Message = "This greeting should not be added",
                    };

                    myTemplate.SaveGreetingTemplate(3, overlapGreeting);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"there was an error: {ex.Message}");
                }


            }
        }
        else
        {
            Console.WriteLine("You did not press a number");
        }

    }

    

}