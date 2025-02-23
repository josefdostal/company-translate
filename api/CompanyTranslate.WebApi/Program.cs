using CompanyTranslate.Application.Extensions.ServiceCollection;
using CompanyTranslate.WebApi.Middlewares.ExceptionHandlers;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

Configure(app, app.Environment);

app.Run();
return;

// Add services to the container.
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddControllers();

    services.AddBaseService(configuration);
}

// Configure the HTTP request pipeline.
void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<LanguageNotFoundExceptionHandlerMiddleware>();

    app.UseRouting();
    app.UseEndpoints(ep => ep.MapControllers());

    // app.UseHttpsRedirection();
}