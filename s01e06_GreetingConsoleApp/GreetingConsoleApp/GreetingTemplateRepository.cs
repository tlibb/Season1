namespace GreetingConsoleApp;

public class GreetingTemplateRepository
{
	public Dictionary<int, Greeting> GreetingTemplates { get; set; }

    public GreetingTemplateRepository()
    {
        var myDict = new Dictionary<int, Greeting>();

        var dictGreeting1 = new Greeting
        {
            Message = "My first dictionary greeting",
        };
        myDict.Add(0, dictGreeting1);

        var dictGreeting2 = new Greeting
        {
            Message = "My second dictionary greeting",
        };
        myDict.Add(1, dictGreeting2);

        var dictGreeting3 = new Greeting
        {
            Message = "My third dictionary greeting",
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

}
