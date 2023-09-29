using SolarThemer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SolarThemer.Services.Implementations
{
    public class DaytimeService : IDaytimeService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DaytimeService> _logger;
        public DaytimeService(ILogger<DaytimeService> logger, IConfiguration configuration) 
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<SunriseSunsetData?> GetSolarScope()
        {
            var baseUrl = new Uri(_configuration["Services:SunriseSunsetApi"] ?? "");
            var latitude = _configuration["Latitude"] ?? "";
            var longitude = _configuration["Longitude"] ?? "";


            using var httpClient = new HttpClient();
            {
                httpClient.BaseAddress = baseUrl;                
                var queryParameters = new Dictionary<string, string>
                {
                    { "lat", latitude },
                    { "long", longitude }
                };
                var encodedParams = new FormUrlEncodedContent(queryParameters);
                var queryString = await encodedParams.ReadAsStringAsync();

                var response = await httpClient.GetAsync($"json?{queryString}");

                if(response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync() ?? "";
                    SunsetSunriseResults? result = JsonSerializer.Deserialize<SunsetSunriseResults>(response.Content.ReadAsStream());

                    return result != null ? result.results : null;
                } 
                else
                {
                    _logger.LogError(response.ReasonPhrase, response.StatusCode);
                    return null;
                }
                
                

            }
        }
    }
}
