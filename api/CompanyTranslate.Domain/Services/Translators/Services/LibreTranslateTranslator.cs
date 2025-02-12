using CompanyTranslate.Domain.Services.Translators.Dtos;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Models;

namespace CompanyTranslate.Domain.Services.Translators.Services;

/// <summary>
/// Adapter to LibreTranslate service
/// </summary>
public class LibreTranslateTranslator(ILibreTranslateClient client) : ITranslator
{
	public async Task<TranslationDto?> GetTranslationAsync(string text,
	                                                       string sourceLanguage,
	                                                       string targetLanguage,
	                                                       CancellationToken cancellationToken = default)
	{
		var request = new TranslationRequest(text, sourceLanguage, targetLanguage);
		try
		{
			var response = await client.TranslateAsync(request, cancellationToken);
			var translations = response.Alternatives.Prepend(response.TranslatedText).ToList();
			var result = new TranslationDto(translations);
			return result;
		}
		catch
		{
			return null;
		}
	}
}