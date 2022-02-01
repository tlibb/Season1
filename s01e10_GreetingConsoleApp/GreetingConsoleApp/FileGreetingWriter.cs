﻿using System;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.File;

namespace GreetingConsoleApp;

public class FileGreetingWriter : IGreetingWriter
{
    private static readonly Logger _logger;
	static FileGreetingWriter()
	{

        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("C:/Users/TINLI/Documents/Exercises/s01e10_GreetingConsoleApp/GreetingConsoleApp/appsettings.json")                        //appsettings.json is our settings file
            .Build();

        var settings = config.GetRequiredSection("Settings").Get<Settings>();

        _logger = new LoggerConfiguration()
             //.WriteTo.Console()
             .WriteTo.File(settings.GreetingWriterOutputFilePath, rollingInterval: RollingInterval.Day)
             .CreateLogger();
    }

    public void Write(string message)
    {
        _logger.Write(Serilog.Events.LogEventLevel.Information, message);   
    }

    
}
