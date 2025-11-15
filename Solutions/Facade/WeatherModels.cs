using System.Text.Json.Serialization;

namespace Facade
{
    public class WeatherResponse
    {
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("main")] public MainInfo? Main { get; set; }
        [JsonPropertyName("weather")] public WeatherInfo[]? Weather { get; set; }
    }

    public class MainInfo
    {
        [JsonPropertyName("temp")] public double Temp { get; set; }
        [JsonPropertyName("feels_like")] public double FeelsLike { get; set; }
        [JsonPropertyName("humidity")] public int Humidity { get; set; }
    }

    public class WeatherInfo
    {
        [JsonPropertyName("main")] public string Main { get; set; } = string.Empty;
        [JsonPropertyName("description")] public string Description { get; set; } = string.Empty;
    }
}
