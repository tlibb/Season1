namespace GreetingConsoleApp;
public class NewyearGreeting : Greeting
{
    public override string GetMessage()
    {
        var baseMessage = base.GetMessage();
        return $"{baseMessage} - It's {DateTime.Now.Year}";
    }
   
}