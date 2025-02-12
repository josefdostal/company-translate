using CompanyTranslate.Domain.Services.Translators.Dtos;

namespace CompanyTranslate.Domain.Services.Translators;

public interface ITranslator
{
	Task<TranslationDto?> GetTranslationAsync(string text, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken = default);
}