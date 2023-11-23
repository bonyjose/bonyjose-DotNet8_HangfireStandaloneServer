using Hangfire;
using HangfireServerCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
     .ConfigureWebHostDefaults(builder =>
     {
         builder.Configure(app =>
         {
             app.UseRouting();

             app.UseHangfireDashboard();
             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapHangfireDashboard();
             });
         });
     })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHangfire(configuration => configuration
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(hostContext.Configuration.GetConnectionString("DefaultConnection")));

        services.AddHangfireServer();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();

//var builder = new ConfigurationBuilder();
//BuildConfig(builder);
//Log.Logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Build())
//    .Enrich.FromLogContext()
//    .WriteTo.Console()
//    .CreateLogger();

//Log.Information("Application Starting");
//var host = Host.CreateDefaultBuilder()
//    .ConfigureServices((context, services) =>
//    {
//        DependencyBuilder.RegisterDependencies(services);
//        services.BuildServiceProvider();
//    })
//    .UseSerilog()
//    .Build();
//using var serviceScope = host.Services.CreateScope();
//var services = serviceScope.ServiceProvider;
//var app = services.GetRequiredService<App>();

//await app.RunAsync(args);

//Log.Information("Application Ending");
//Console.ReadLine();
//    }
//    static void BuildConfig(IConfigurationBuilder builder)
//{
//    builder.SetBasePath(Directory.GetCurrentDirectory())
//        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//        .AddEnvironmentVariables();
//}


