namespace GreetingConsoleApp;

public class ChristmasGreeting : Greeting
{
    public override string GetMessage()
    {
        string baseMessage = base.GetMessage();
        return $"{baseMessage} - Your present is a hug";
    } 
}