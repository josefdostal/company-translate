using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Models;

public record TranslationRequest(string Text, string Source, string Target, int Alternatives = 3)
{
	[JsonProperty("q")]
	public string Text { get; init; } = Text;
	[JsonProperty("source")]
	public string Source { get; init; } = Source;
	[JsonProperty("target")]
	public string Target { get; init; } = Target;
	[JsonProperty("alternatives")]
	public int Alternatives { get; init; } = Alternatives;
}