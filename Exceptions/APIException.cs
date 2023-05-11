namespace command_line_weather.Exceptions;

public class ApiException : Exception
{
    public ApiException(string message) : base(message)
    {
    }
}