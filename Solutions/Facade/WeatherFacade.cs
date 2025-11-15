using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Facade
{
    public class WeatherFacade : IWeatherFacade
    {
        private static readonly HttpClient _http = new HttpClient();
        private readonly string _apiKey;
        private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5/";

        public WeatherFacade(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("API key must be provided via constructor parameter.", nameof(apiKey));

            _apiKey = apiKey;

            if (_http.BaseAddress == null)
            {
                _http.BaseAddress = new Uri(_baseUrl);
            }
        }

        public async Task<double?> GetCurrentTemperatureCelsiusAsync(string city)
        {
            var weather = await GetCurrentWeatherAsync(city).ConfigureAwait(false);
            return weather?.Main?.Temp;
        }

        public async Task<string?> GetShortWeatherDescriptionAsync(string city)
        {
            var weather = await GetCurrentWeatherAsync(city).ConfigureAwait(false);
            if (weather == null)
                return null;

            var temp = weather.Main?.Temp;
            var humidity = weather.Main?.Humidity;
            var descr = weather.Weather?.Length > 0 ? weather.Weather[0].Description : string.Empty;

            return $"{weather.Name}: {temp} °C, humidity: {humidity}%, {descr}";
        }

        private async Task<WeatherResponse?> GetCurrentWeatherAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(_apiKey))
                return null;

            // Build query: q={city}&appid={apikey}&units=metric
            var uri = $"weather?q={Uri.EscapeDataString(city)}&appid={_apiKey}&units=metric";
            try
            {
                var response = await _http.GetAsync(uri).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                    return null;

                var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<WeatherResponse>(responseBody, options);
                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
