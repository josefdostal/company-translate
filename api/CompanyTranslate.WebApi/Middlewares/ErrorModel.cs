using Newtonsoft.Json;

namespace CompanyTranslate.WebApi.Middlewares;

public record ErrorModel(string Message)
{
	[JsonProperty("message")]
	public string Message { get; set; } = Message;
}