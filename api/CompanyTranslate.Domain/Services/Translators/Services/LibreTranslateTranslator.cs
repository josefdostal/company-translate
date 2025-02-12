using CompanyTranslate.Domain.Services.Translators.Dtos;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Models;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Services;

namespace CompanyTranslate.Domain.Services.Translators.Services;

/// <summary>
/// Adapter to LibreTranslate service
/// </summary>
public class LibreTranslateTranslator(LibreTranslate client) : ITranslator
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
			var result = new TranslationDto(response.TranslatedText, response.Alternatives);
			return result;
		}
		catch
		{
			return null;
		}
	}
}