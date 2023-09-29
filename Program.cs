using SolarThemer;
using SolarThemer.Services;
using SolarThemer.Services.Implementations;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IDaytimeService, DaytimeService>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
