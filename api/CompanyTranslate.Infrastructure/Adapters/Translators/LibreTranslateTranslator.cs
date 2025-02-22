using CompanyTranslate.Domain.Entities.Translations;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Models;
using ITranslator = CompanyTranslate.Domain.Interfaces.Translations.ITranslator;

namespace CompanyTranslate.Infrastructure.Adapters.Translators;

public class LibreTranslateTranslator(ILibreTranslateClient client) : ITranslator
{
	public async Task<Translation?> GetTranslationAsync(string text,
	                                                       string sourceLanguage,
	                                                       string targetLanguage,
	                                                       CancellationToken cancellationToken = default)
	{
		var request = new TranslationRequest(text, sourceLanguage, targetLanguage);
		try
		{
			var response = await client.TranslateAsync(request, cancellationToken);
			var translations = response.Alternatives.Prepend(response.TranslatedText).ToList();
			var result = new Translation(translations);
			
			return result;
		}
		catch (HttpRequestException)
		{
			return null;
		}
	}
}