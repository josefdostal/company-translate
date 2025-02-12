using CompanyTranslate.Application.Services.Translations;
using CompanyTranslate.WebApi.Controllers.Translations.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyTranslate.WebApi.Controllers.Translations;

[Controller]
[Route("api/v1/translations")]
public class TranslationsController(ITranslationService translationService) : ControllerBase
{
	[HttpGet]
	[Route("{text}/{sourceLanguage}/{targetLanguage}")]
	public async Task<IActionResult> GetTranslationAsync([FromRoute]TranslationRequest request, CancellationToken cancellationToken)
	{
		var translation = await translationService.TranslateAsync(request.Text, request.SourceLanguage, request.TargetLanguage, cancellationToken);
		if (translation == null)
			return NotFound();
		var result = new TranslationResponse(translation.Translations);
		return Ok(result);
	}
}