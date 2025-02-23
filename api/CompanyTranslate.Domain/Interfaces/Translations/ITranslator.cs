using CompanyTranslate.Domain.Entities.Translations;

namespace CompanyTranslate.Domain.Interfaces.Translations;

public interface ITranslator
{
	Task<Translation?> GetTranslationAsync(string text, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken = default);
}