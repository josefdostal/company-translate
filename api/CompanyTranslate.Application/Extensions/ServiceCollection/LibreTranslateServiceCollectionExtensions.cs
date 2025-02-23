using CompanyTranslate.Infrastructure.Configuration.Translate;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CompanyTranslate.Application.Extensions.ServiceCollection;

public static class LibreTranslateServiceCollectionExtensions
{
	public static IServiceCollection AddLibreTranslateClient(this IServiceCollection @this)
	{
		@this.AddHttpClient<ILibreTranslateClient, LibreTranslateClient>((prov, client) =>
		{
			client.BaseAddress = prov.GetRequiredService<IOptions<LibreTranslateConfiguration>>().Value.Url;
		});
		
		return @this;
	}
}