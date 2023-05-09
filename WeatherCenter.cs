using System.Globalization;
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
            throw new ApiException("Weather API call failed");
        }
        
        var forecast = await response.Content.ReadAsAsync<Forecast>();
        return forecast;
    }
    
    static async Task<Location> GetLocation(string path)
    {
        var response = await _client.GetAsync(path);
        if (!response.IsSuccessStatusCode)
        {
            throw new ApiException("Location API call failed");
        }
        
        var location = await response.Content.ReadAsAsync<Location>();
        return location;
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
            var location = await GetLocation("http://ip-api.com/json/");
            
            // Format culturally agnostic strings for the latitude and longitude for API call
            var latitudeString = location.Lat.ToString(CultureInfo.InvariantCulture);
            var longitudeString = location.Lon.ToString(CultureInfo.InvariantCulture);
            
            var weather = await GetWeather($"https://api.open-meteo.com/v1/forecast?latitude={latitudeString}&longitude={longitudeString}&current_weather=true&timezone=auto");

            var table = new ConsoleTable("Temperature", "Wind Speed");
            table.AddRow(
                $"{weather.Current_weather.Temperature}°C",
                $"{weather.Current_weather.Windspeed} kmh"
            );
            
            Console.WriteLine("Current weather for {0}, {1}, {2}", location.City, location.RegionName, location.Country);
            table.Write();
            Console.WriteLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

}