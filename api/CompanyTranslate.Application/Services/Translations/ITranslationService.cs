using CompanyTranslate.Application.Dtos.Translations;

namespace CompanyTranslate.Application.Services.Translations;

public interface ITranslationService
{
	Task<TranslationDto?> GetTranslationAsync(string text, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken = default);
}