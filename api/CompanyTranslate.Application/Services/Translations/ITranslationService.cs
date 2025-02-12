using CompanyTranslate.Application.DTOs.Translations;

namespace CompanyTranslate.Application.Services.Translations;

public interface ITranslationService
{
	Task<TranslationDto?> TranslateAsync(string text, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken = default);
}