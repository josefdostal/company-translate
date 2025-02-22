using CompanyTranslate.Application.Dtos.Translations;
using CompanyTranslate.Domain.Services;

namespace CompanyTranslate.Application.Services.Translations;

public class TranslationService (ITranslationResolverService translationService) : ITranslationService
{
	public async Task<TranslationDto?> GetTranslationAsync(string text, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken = default)
	{
		var translation = await translationService.TranslateAsync(text, sourceLanguage, targetLanguage, cancellationToken);
		
		if(translation is null)
			return null;
		
		var result = new TranslationDto(translation.Translations);
		
		return result;
	}
}