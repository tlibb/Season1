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

        private static readonly Settings _settings;

        static XMLGreetingWriter()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")                        //appsettings.xml is our settings file
                .Build();

            // Get values from the config given their key and their target type.
            //_settings = config.GetRequiredSection("Settings").Get<Settings>();

            _settings = config.GetRequiredSection("Settings").Get<Settings>();

            
        }
        public void Write(string message)
        {
            throw new NotImplementedException();
        }

        public void Write(Greeting greeting)
        {
            throw new NotImplementedException();
        }

        public void Write(IEnumerable<Greeting> greetings)
        {
            var xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true,
            };

            var xmlWriter = XmlWriter.Create(GetFilename(_settings.GreetingWriterOutputFilePath), xmlWriterSettings);
            var serializer = new XmlSerializer(typeof(List<Greeting>));                             //this xml serializer does not support serializing interfaces, need to convert to a concrete class
            serializer.Serialize(xmlWriter, greetings.ToList());                                   //convert our greetings of type IEnumerable (interface) to List (concrete class)

            Console.WriteLine($"Wrote {greetings.Count()} greeting(s) to {GetFilename(_settings.GreetingWriterOutputFilePath)}"); 
        }

        public string GetFilename(string path)
        {
            var listOfStrings = path.Split(".");
            var mytimestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var PathWithTimeStamp = String.Concat(listOfStrings[0], mytimestamp, ".", listOfStrings[1]);

            return PathWithTimeStamp;
        }
    }
}
