namespace CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Models;

public record TranslationRequest(string Q, string Source, string Target, int Alternatives = 3);