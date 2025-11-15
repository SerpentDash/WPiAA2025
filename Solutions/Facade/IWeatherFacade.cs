using System.Threading.Tasks;

namespace Facade
{
    public interface IWeatherFacade
    {
        /// <summary>
        /// Returns current temperature in Celsius for a given city name.
        /// Returns null if the value could not be obtained.
        /// </summary>
        Task<double?> GetCurrentTemperatureCelsiusAsync(string city);

        /// <summary>
        /// Returns a short formatted description of current weather for the city (temperature, humidity and description)
        /// </summary>
        Task<string?> GetShortWeatherDescriptionAsync(string city);
    }
}
