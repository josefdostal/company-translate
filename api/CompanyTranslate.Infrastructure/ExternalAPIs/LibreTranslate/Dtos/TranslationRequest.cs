namespace CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Dtos;

public record TranslationRequest(string Phrase, string Source, string Target);