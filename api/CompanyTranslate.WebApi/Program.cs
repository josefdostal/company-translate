using CompanyTranslate.Application.Services.Translations;
using CompanyTranslate.Application.Services.Translations.Implementations;
using CompanyTranslate.Domain.Services.Translators;
using CompanyTranslate.Domain.Services.Translators.Services;
using CompanyTranslate.Infrastructure.Configuration.Translate;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Services;
using Microsoft.Extensions.Options;

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

    services.Configure<LibreTranslateConfiguration>(configuration.GetSection("LibreTranslate"));
    services.AddTransient<ITranslationService, TranslationService>();
    services.AddTransient<ITranslator, LibreTranslateTranslator>();
    services.AddHttpClient<ILibreTranslateClient, LibreTranslate>((svcs, opts) =>
    {
        opts.BaseAddress = svcs.GetService<IOptions<LibreTranslateConfiguration>>()?.Value.Url;
    });
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