using Microsoft.Extensions.Logging;
using SolarThemer.Model;
using SolarThemer.Services;

namespace SolarThemer;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IDaytimeService _daytimeService;    

    public Worker(ILogger<Worker> logger, IDaytimeService daytimeService)
    {
        _logger = logger;
        _daytimeService = daytimeService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            
            if(ScheduleModel.CurrentDate == null) 
            {
                var results = await _daytimeService.GetSolarScope();
                if(results != null)
                {
                    _logger.LogInformation(results.sunrise);
                }
            }
        }
    }
}
