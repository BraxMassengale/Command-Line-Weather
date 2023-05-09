namespace command_line_weather;

public class Weather
{
    public double Temperature { get; set; }
    public double Windspeed { get; set; }
    public double? Winddirection { get; set; }
    public int? Weathercode { get; set; }
    public int? IsDay { get; set; }
    public string? Time { get; set; }
}