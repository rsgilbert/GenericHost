

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
Console.WriteLine("Created builder");
builder.Services.AddHostedService<MyHostedService>();
builder.Services.AddHostedService<CheckEnvironment>();
Console.WriteLine("Added hosted service");
IHost host = builder.Build();
Console.WriteLine("Built host");
host.Run();


Console.WriteLine("host has been stopped");
// Console.WriteLine("Lets start the app again so user has to shut it down again");
// builder = Host.CreateApplicationBuilder(args);
// builder.Services.AddHostedService<MyHostedService>();
// host = builder.Build();
// host.Run();