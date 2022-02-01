using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GreetingConsoleApp
{
    internal class GreetingReader
    {
        public IEnumerable<Greeting> ReadGreetingsFromFile(string path)
        {
            try
            {
                string jsonstr = File.ReadAllText(path);
                IEnumerable<Greeting> greetings = JsonSerializer.Deserialize<IEnumerable<Greeting>>(jsonstr);
                return greetings;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");               
            }
            return new List<Greeting>(); // I find this weird, why does the code not always go here after try?
                                         // Answer: because the function exits when it has hit a return statement!
                                         // If we anyhow want to execute something: use a finally statement


        }
    }
}
