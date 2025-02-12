namespace CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Dtos;

public record TranslationResult(string TranslatedText, List<string> Alternatives);