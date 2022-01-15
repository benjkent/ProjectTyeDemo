
namespace ProjectTyeDemo.App.Data
{
    public class WeatherForecastService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherForecastService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<WeatherForecast>> GetForecastAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("weatherapi");
            
            var result = await httpClient.GetFromJsonAsync<WeatherForecast[]>("/WeatherForecast");
            return result ?? Enumerable.Empty<WeatherForecast>();
        }
        public async Task<IEnumerable<WeatherForecast>> GetForecastAsyncDebug()
        {
            var httpClient = _httpClientFactory.CreateClient("weatherapi-debug");
            var result = await httpClient.GetFromJsonAsync<WeatherForecast[]>("/WeatherForecast");
            return result ?? Enumerable.Empty<WeatherForecast>();
        }
    }
}