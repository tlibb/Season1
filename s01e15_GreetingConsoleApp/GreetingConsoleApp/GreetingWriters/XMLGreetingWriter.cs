using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;

namespace GreetingConsoleApp
{
    internal class XMLGreetingWriter : IGreetingWriter
    {
        //this is what the exercise suggested:
        //private static readonly Settings _settings;

        private static readonly XmlWriter _xmlWriter;


        static XMLGreetingWriter()
        {
            //This is what we had before

            //IConfiguration config = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json")                        //appsettings.xml is our settings file
            //    .Build();

            

            //_settings = config.GetRequiredSection("Settings").Get<Settings>();

            //This is what the exercise on refractoring suggested:

            //_settings = Program.InitializeSettings();

            var xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
            };

            //check whether this is a good idea to put here! How does it open files and closes them? Are they hanging?
            //Can they be accessed from other methods?
            _xmlWriter = XmlWriter.Create(GetFilename(Program.settings.GreetingWriterOutputFilePath), xmlWriterSettings);


        }
        public void Write(string message)
        {
            var serializer = new XmlSerializer(typeof(string));
            serializer.Serialize(_xmlWriter, message);

            Console.WriteLine($"Wrote a string message to {GetFilename(Program.settings.GreetingWriterOutputFilePath)} ");
        }

        public void Write(Greeting greeting)
        {
            var serializer = new XmlSerializer(typeof (Greeting));
            serializer.Serialize(_xmlWriter, greeting);

            Console.WriteLine($"Wrote a Greeting object to {GetFilename(Program.settings.GreetingWriterOutputFilePath)}");
        }

        public void Write(IEnumerable<Greeting> greetings)
        {
            var serializer = new XmlSerializer(typeof(List<Greeting>));                             //this xml serializer does not support serializing interfaces, need to convert to a concrete class
            serializer.Serialize(_xmlWriter, greetings.ToList());                                   //convert our greetings of type IEnumerable (interface) to List (concrete class)

            Console.WriteLine($"Wrote {greetings.Count()} greeting(s) to {GetFilename(Program.settings.GreetingWriterOutputFilePath)}"); 
        }

        public static string GetFilename(string path)
        {
            var listOfStrings = path.Split("."); //the only thing that does not work here is when there are multiple . in the path, should fix that!
            var mytimestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var PathWithTimeStamp = String.Concat(listOfStrings[0], mytimestamp, ".xml");

            return PathWithTimeStamp;
        }
    }
}
