namespace GreetingConsoleApp;

public class GreetingTemplateRepository
{
	public Dictionary<int, Greeting> GreetingTemplates { get; set; }

    public GreetingTemplateRepository()
    {
        var myDict = new Dictionary<int, Greeting>();

        var dictGreeting1 = new Greeting
        {
            Message = "Short message",
        };
        myDict.Add(0, dictGreeting1);

        var dictGreeting2 = new Greeting
        {
            Message = "This is a longer message, hope it selects this one",
        };
        myDict.Add(1, dictGreeting2);

        var dictGreeting3 = new Greeting
        {
            Message = "And another long message to select for testing purposes",
        };
        myDict.Add(2, dictGreeting3);   

        GreetingTemplates = myDict;

    }

    public Greeting GetGreetingTemplate(int id)
    {
       if(GreetingTemplates.ContainsKey(id))
        {   
            return GreetingTemplates[id];   
        }
        else
        {
            throw new Exception("key not found");
        }
        //return GreetingTemplates[id];
    }

    public void SaveGreetingTemplate(int id, Greeting greeting)
    {
        if (GreetingTemplates.ContainsKey(id))
        {
            throw new Exception("key already exists");
        }
        else
        {
            GreetingTemplates.Add(id, greeting);
        }
    }

    public IEnumerable<Greeting> GetGreetingTemplatesByLengthWithLinq(int length)
    {
        var greetings = from g in GreetingTemplates 
                        where g.Value.Message.Length >= length
                        select g.Value;
        
        return greetings;

    }

    public IEnumerable<Greeting> GetGreetingTemplatesByLengthWithLambda(int length)
    {
        var greetings = GreetingTemplates.Where(g => g.Value.Message.Length >= length)
                                         .Select(g => g.Value);
        
        return greetings;
    }

    public IEnumerable<Greeting> GetGreetingTemplatesByLengthWithForeach(int length)
    {
        var greetings = new List<Greeting>();

        foreach (Greeting g in GreetingTemplates.Values)
        {
            if(g.Message.Length >= length)
            {
                greetings.Add(g);
            }
        }

        return greetings;
    }

    public IEnumerable<Greeting> GetGreetingTemplatesBySearchStringWithLinq(string compString)
    {
        var greetings = from g in GreetingTemplates
                        where g.Value.Message.Contains(compString)
                        select g.Value;

        return greetings;
    }

    public IEnumerable<Greeting> GetGreetingTemplatesBySearchStringWithLambda(string compString)
    {
        var greetings = GreetingTemplates.Where(g => g.Value.Message.Contains(compString))
                                         .Select(g => g.Value);

        return greetings;
    }

    public IEnumerable<Greeting> GetGreetingTemplatesBySearchStringWithForeach(string compString)
    {
        var greetings = new List<Greeting>();

        foreach(Greeting g in GreetingTemplates.Values)
        {
            if(g.Message.Contains(compString))
            {
                greetings.Add(g);
            }
        }

        return greetings;

    }
}
