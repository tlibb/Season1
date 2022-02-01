﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingConsoleApp
{
    
    public class CsvGreetingWriter : IGreetingWriter
    {
        private readonly string _path;

        public CsvGreetingWriter()
        {
            _path = Program.settings.GreetingWriterOutputFilePath;
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
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Message;From;To;TimeStamp");

            foreach (Greeting g in greetings)
            {
                sb.AppendLine($"{g.Message};{g.From};{g.To};{g.TimeStamp}");
            }

            File.WriteAllText(GetFilename(_path), sb.ToString());

            Console.WriteLine($"Wrote {greetings.Count()} to {GetFilename(_path)}");

        }
        public string GetFilename(string path)
        {
            var listOfStrings = path.Split("."); 
            var mytimestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var PathWithTimeStamp = String.Concat(listOfStrings[0], mytimestamp, ".csv");

            return PathWithTimeStamp;
        }
    }
}
