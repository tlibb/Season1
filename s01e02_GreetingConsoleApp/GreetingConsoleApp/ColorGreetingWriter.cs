namespace GreetingConsoleApp;

public class ColorGreetingWriter : IGreetingWriter
{ 
    public System.ConsoleColor MyColor { get; set; } = ConsoleColor.DarkMagenta; //default is DarkMagenta but can be set to any color by the user
    public void Write(string message)
    { 
        Console.ForegroundColor = MyColor;
        Console.WriteLine(message);
        Console.WriteLine();
        Console.ResetColor();
    }
}