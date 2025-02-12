namespace CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Models;

public record TranslationResponse(string TranslatedText, List<string> Alternatives);