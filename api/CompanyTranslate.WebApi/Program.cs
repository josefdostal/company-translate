using CompanyTranslate.Application.Extensions.ServiceCollection;
using CompanyTranslate.Application.Services.Translations;
using CompanyTranslate.Domain.Interfaces.Translations;
using CompanyTranslate.Domain.Services;
using CompanyTranslate.Domain.Services.Translations;
using CompanyTranslate.Infrastructure.Adapters.Translators;
using CompanyTranslate.Infrastructure.Configuration.Translate;

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
    services.AddControllers().AddNewtonsoftJson();

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

    app.UseRouting();
    app.UseEndpoints(ep => ep.MapControllers());

    // app.UseHttpsRedirection();
}