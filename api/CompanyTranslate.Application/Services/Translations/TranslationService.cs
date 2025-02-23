using CompanyTranslate.Application.Dtos.Translations;
using CompanyTranslate.Domain.Services.Translations;
using LanguageNotSupportedException = CompanyTranslate.Application.Exceptions.LanguageNotSupportedException;
using LtEx = CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Exceptions;

namespace CompanyTranslate.Application.Services.Translations;

public class TranslationService (ITranslationResolver translationResolver) : ITranslationService
{
	public async Task<TranslationDto?> GetTranslationAsync(string text, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken = default)
	{
		// TODO validate supported languages
		try
		{
			var translation = await translationResolver.TranslateAsync(text, sourceLanguage, targetLanguage, cancellationToken);
			
			if(translation is null)
				return null;
			
			var result = new TranslationDto(translation.Translations);
			
			return result;
		}
		catch(LtEx.LanguageNotSupportedException ex)
		{
			throw new LanguageNotSupportedException(ex.Message);
		}
	}
}