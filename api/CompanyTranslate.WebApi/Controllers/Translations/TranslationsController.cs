using Microsoft.AspNetCore.Mvc;

namespace CompanyTranslate.WebApi.Controllers.Translations;


[Controller]
[Route("api/v1/translations")]
public class TranslationsController : ControllerBase
{
	[HttpGet]
	[Route("translations/{phrase}")]
	public async Task<string> GetTranslationsAsync(string phrase, CancellationToken cancellationToken)
	{
		return "";
	}
}