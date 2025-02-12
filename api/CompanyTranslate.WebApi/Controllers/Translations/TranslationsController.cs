using CompanyTranslate.Application.Services.Translations;
using Microsoft.AspNetCore.Mvc;

namespace CompanyTranslate.WebApi.Controllers.Translations;

[Controller]
[Route("api/v1/translations")]
public class TranslationsController(ITranslationService translationService) : ControllerBase
{
	[HttpGet]
	[Route("{text}/{sourceLanguage}/{targetLanguage}")]
	public async Task<IActionResult> TranslateAsync(string text, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken)
	{
		var result = await translationService.TranslateAsync(text, sourceLanguage, targetLanguage, cancellationToken);
		if (result == null)
			return NotFound();
		return Ok(result);
	}
}