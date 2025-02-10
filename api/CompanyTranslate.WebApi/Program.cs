var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

Configure(app, app.Environment);

app.Run();
return;

// Add services to the container.
void ConfigureServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddControllers();
}

// Configure the HTTP request pipeline.
void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseRouting();
    app.UseEndpoints(ep => ep.MapControllers());

    // app.UseHttpsRedirection();
}