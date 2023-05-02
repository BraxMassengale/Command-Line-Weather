using System.Net.Http.Headers;
using System.Runtime.InteropServices.JavaScript;

namespace command_line_weather;

public class Weather
{
    static HttpClient client = new HttpClient();
    
    static async Task<String> GetWeather(string path)
    {
        String weather = "";   
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            weather = await response.Content.ReadAsAsync<JSObject>();
        }
        return weather;
    }
    
    public static async Task RunAsync()
    {
        // Update port # in the following line.
        client.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        try
        {
            String weather = await GetWeather("https://api.open-meteo.com/v1/forecast?latitude=43.25&longitude=-2.93&hourly=temperature_2m");
            Console.WriteLine(weather);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.ReadLine();
    }

}