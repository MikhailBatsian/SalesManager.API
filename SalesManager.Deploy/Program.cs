using SalesManager.Deploy;

Console.WriteLine("Data seed started");

var builder = Host.CreateDefaultBuilder();

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .AddJsonFile("appsettings.json")
    .Build();

builder.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>().UseConfiguration(configuration));

var app = builder.Build();

var initializer = app.Services.GetRequiredService<DataSeedService>();

await initializer.SeedDataAsync();

Console.WriteLine("Data seed finished");
