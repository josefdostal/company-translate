namespace CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Dtos;

public record SupportedLangaugeResponse
{
	public string Code { get; set; }
	public string Name { get; set; }
	public List<string> Targets { get; set; }
}