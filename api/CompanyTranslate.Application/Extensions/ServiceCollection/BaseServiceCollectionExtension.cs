using CompanyTranslate.Application.Services.Translations;
using CompanyTranslate.Domain.Services.Translations;
using CompanyTranslate.Infrastructure.Configuration.Translate;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyTranslate.Application.Extensions.ServiceCollection;

public static class BaseServiceCollectionExtension
{
	public static IServiceCollection AddBaseService(this IServiceCollection @this, IConfiguration configuration)
	{
		@this.Configure<LibreTranslateConfiguration>(configuration.GetSection("LibreTranslate"));
		@this.AddTransient<ITranslationService, TranslationService>();
		@this.AddTransient<ITranslationResolver, TranslationResolver>();
		
		@this.AddTranslators();
		@this.AddLibreTranslateClient();
    
		return @this;
	}
}