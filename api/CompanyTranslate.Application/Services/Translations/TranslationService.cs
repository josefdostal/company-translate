using CompanyTranslate.Application.Dtos.Translations;

namespace CompanyTranslate.Application.Services.Translations;

public class TranslationService (ITranslationService translationService) : ITranslationService
{
	public async Task<TranslationDto?> GetTranslationAsync(string text, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken = default)
	{
		var translation = await translationService.GetTranslationAsync(text, sourceLanguage, targetLanguage, cancellationToken);
		if(translation is null)
			return null;
		
		var result = new TranslationDto(translation.Translations);
		
		return result;
	}
}