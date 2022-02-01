using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace GreetingConsoleApp;

    internal class JsonGreetingWriter : IGreetingWriter
    {
        private static readonly string _path;

        private static readonly JsonSerializerOptions _options;

        static JsonGreetingWriter()
        {
           // IConfiguration config = new ConfigurationBuilder()
           //.AddJsonFile("appsettings.json")                        //appsettings.json is our settings file
           //.Build();

            

           // var settings = config.GetRequiredSection("Settings").Get<Settings>();

          //  var settings = Program.InitializeSettings();
            _path = Program.settings.GreetingWriterOutputFilePath;
            _options = new() { WriteIndented = true };
        }
        
        public string GetFilename(string path)
        {
            var listOfStrings = path.Split(".");
            var mytimestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var PathWithTimeStamp = String.Concat(listOfStrings[0], mytimestamp, ".", listOfStrings[1]);

            return PathWithTimeStamp;
        }

        public void Write(string message)
        {
            
            string json = JsonSerializer.Serialize(message, _options);
            var PathWithTimeStamp = GetFilename(_path);
            File.WriteAllText(PathWithTimeStamp, json);
            Console.WriteLine($"Wrote a message to a json file {_path}");

        }

        public void Write(Greeting greeting)
        {
            string json = JsonSerializer.Serialize(greeting, _options);
            var PathWithTimeStamp = GetFilename(_path);
            File.WriteAllText(PathWithTimeStamp, json);
            Console.WriteLine($"Wrote a Greeting object to a json file {_path}");
        }

        public void Write(IEnumerable<Greeting> greetings)
        {
            string json = JsonSerializer.Serialize(greetings, _options);
            var PathWithTimeStamp = GetFilename(_path);
            File.WriteAllText(PathWithTimeStamp, json);
            Console.WriteLine($"Wrote a collection of Greeting objects to a json file {_path}");
        }
    }

