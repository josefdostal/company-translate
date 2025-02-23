using CompanyTranslate.Domain.Entities.Translations;

namespace CompanyTranslate.Domain.Services.Translations;

public interface ITranslationResolver
{
	Task<Translation?> TranslateAsync(string text, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken = default);
}