using System;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.File;

namespace GreetingConsoleApp;

public class FileGreetingWriter : IGreetingWriter
{
    private static readonly Logger _logger;
	static FileGreetingWriter()
	{
        _logger = new LoggerConfiguration()
             //.WriteTo.Console()
             .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
             .CreateLogger();
    }

    public void Write(string message)
    {
        _logger.Write(Serilog.Events.LogEventLevel.Information, message);
    }

    
}
