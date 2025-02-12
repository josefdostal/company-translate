using CompanyTranslate.Application.DTOs.Translations;
using CompanyTranslate.Domain.Services.Translators;

namespace CompanyTranslate.Application.Services.Translations;

public class TranslationService(IEnumerable<ITranslator> translationServices) : ITranslationService
{
	public async Task<TranslationDto?> TranslateAsync(string text, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken = default)
	{
		foreach(var translationService in translationServices)
		{
			var transation = await translationService.GetTranslationAsync(text, sourceLanguage, targetLanguage, cancellationToken);
			if(transation == null)
				continue;

			var result = new TranslationDto(transation.Translation, transation.Alternatives);
			return result;
		}
		return null;
	}
}