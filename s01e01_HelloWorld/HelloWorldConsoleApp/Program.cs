// See https://aka.ms/new-console-template for more information

//basic program to try input and output

Console.WriteLine("Hello, World!");
Console.WriteLine(4);

int mynumber = 5;

string myword = "Tine";
string mysecondword = "Koen";

Console.WriteLine(mynumber);
Console.WriteLine(myword);
Console.WriteLine(myword + " "+ mysecondword);
Console.WriteLine($"blabla: {myword} and {mysecondword}");

Console.WriteLine("blabla " + myword + mynumber);
Console.WriteLine($"blabla: {myword} bla and {mynumber}");

int mytest = 5;

string mycast = mytest.ToString();

Console.WriteLine(mycast.GetType());

int numa = 4;
int numb = 5;

Console.WriteLine(numa+numb);

bool myboolean = true;

Console.WriteLine(myboolean);
Console.WriteLine(numa == numb);

Console.WriteLine("Write a number: ");

string astring = Console.ReadLine();

Console.WriteLine($"my input was: {astring}");

Console.WriteLine("Write a number:");

var myread = Console.ReadLine();


bool mybooltest = long.TryParse(myread, out var longtest);
Console.WriteLine(mybooltest);

if (long.TryParse(myread, out var mylong))
{
    Console.WriteLine(mylong);
}

else
{
    Console.WriteLine("Fail");
}

