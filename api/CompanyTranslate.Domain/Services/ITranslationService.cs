using CompanyTranslate.Domain.Entities.Translations;

namespace CompanyTranslate.Domain.Services;

public interface ITranslationService
{
	Task<Translation?> TranslateAsync(string text, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken = default);
}