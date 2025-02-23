

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
// builder.Services.AddHostedService();

IHost host = builder.Build();
host.Run();