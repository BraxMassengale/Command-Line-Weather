using System.Net.Http.Headers;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using ConsoleTables;

namespace command_line_weather;

public class WeatherCenter
{
    static HttpClient _client = new HttpClient();
    
    static async Task<Forecast> GetWeather(string path)
    {
        var response = await _client.GetAsync(path);
        if (!response.IsSuccessStatusCode)
        {
            throw new ApiException("API call failed");
        }
        
        var forecast = await response.Content.ReadAsAsync<Forecast>();
        return forecast;
    }
    
    public static async Task RunAsync()
    {  
        // Update port # in the following line.
        _client.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        try
        {
            var weather = await GetWeather("https://api.open-meteo.com/v1/forecast?latitude=43.25&longitude=-2.93&current_weather=true&timezone=auto");
            var table = new ConsoleTable("Temperature", "Wind Speed");
            table.AddRow(
                $"{weather.Current_weather.Temperature}°C",
                $"{weather.Current_weather.Windspeed} kmh"
            );

                table.Write();
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

}