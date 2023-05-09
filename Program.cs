// See https://aka.ms/new-console-template for more information

using command_line_weather;

Console.WriteLine("Today's weather is:");  
WeatherCenter.RunAsync().Wait();