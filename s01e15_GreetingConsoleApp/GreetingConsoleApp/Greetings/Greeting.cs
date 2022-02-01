namespace GreetingConsoleApp;

public class Greeting
{
    public string Message { get; set; }
    public string From { get; set; }
    public string To {get; set; }
    public DateTime TimeStamp { get; set; } = DateTime.Now;

    public virtual string GetMessage()
    {
        return $"{TimeStamp} \n{Message}";
    }
    

   

}