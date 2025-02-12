namespace CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Dtos;

public record TranslationResponse
{
	public string TranslatedText { get; set; }
	public List<string> Alternatives { get; set; }
}