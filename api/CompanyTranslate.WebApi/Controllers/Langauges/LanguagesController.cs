using CompanyTranslate.Application.Configurations;
using CompanyTranslate.WebApi.Controllers.Langauges.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CompanyTranslate.WebApi.Controllers.Langauges;

[Controller]
[Route("/api/v1/languages")]
public class LanguagesController(IOptions<CompanyTranslateConfiguration> config) : ControllerBase
{
	[HttpGet]
	public IActionResult Get([FromQuery]bool? isAvailable)
	{
		var result = SupportedLangauge.All
		             .Select(x => new LanguageResponse(x.Code, x.Name, config.Value.AvailableLanguages.Contains(x.Code)))
		             .ToList();
		
		if(isAvailable != null)
			result.RemoveAll(x => x.IsAvailable != isAvailable);

		return new OkObjectResult(result);
	}
}