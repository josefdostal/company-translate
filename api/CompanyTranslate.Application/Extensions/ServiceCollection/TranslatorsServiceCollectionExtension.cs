using CompanyTranslate.Domain.Interfaces.Translations;
using CompanyTranslate.Infrastructure.Adapters.Translators;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyTranslate.Application.Extensions.ServiceCollection;

public static class TranslatorsServiceCollectionExtension
{
	public static IServiceCollection AddTranslators(this IServiceCollection @this)
	{
		@this.AddTransient<ITranslator, LibreTranslateTranslator>();
		
		return @this;
	}
}