namespace command_line_weather.Enums;

public class WeatherCodes
{
    private static readonly Dictionary<int, string> WeatherCodesDescriptions = new Dictionary<int, string>
    {
        {0, "Clear sky ☀️"},
        {1, "Mainly clear 🌤️"},
        {2, "Partly cloudy ⛅️"},
        {3, "Overcast ☁️"},
        {45, "Fog 🌫️"},
        {48, "Depositing rime fog 🌫"},
        {51, "Drizzle: Light ☔️"},
        {53, "Drizzle: Moderate ☔️"},
        {55, "Drizzle: Dense intensity ☔️"},
        {56, "Freezing Drizzle: Light intensity ☔️❄️"},
        {57, "Freezing Drizzle: Dense intensity ☔️❄️"},
        {61, "Rain: Slight intensity 🌧️"},
        {63, "Rain: Moderate intensity 🌧️"},
        {65, "Rain: Heavy intensity 🌧️"},
        {66, "Freezing Rain: Light intensity 🌧️❄️"},
        {67, "Freezing Rain: Heavy intensity 🌧️❄️"},
        {71, "Snow fall: Slight intensity ☃️"},
        {73, "Snow fall: Moderate intensity ☃️"},
        {75, "Snow fall: Heavy intensity ☃️"},
        {77, "Snow grains ❄️"},
        {80, "Rain showers: Slight intensity 🌧️"},
        {81, "Rain showers: Moderate intensity 🌧️"},
        {82, "Rain showers: Violent intensity 🌧️"},
        {85, "Snow showers: Slight intensity 🌧️"},
        {86, "Snow showers: Heavy intensity 🌧️"},
        {95, "Thunderstorm: Slight or moderate intensity ⛈️"},
        {96, "Thunderstorm with hail: Slight intensity ⛈️❄️"},
        {99, "Thunderstorm with hail: Heavy intensity ⛈️❄️"}
    };

    public static string GetDescription(int weatherCode)
    {
        return (WeatherCodesDescriptions.TryGetValue(weatherCode, out var description)) ? description : "Unknown Weather Code";
    }
}