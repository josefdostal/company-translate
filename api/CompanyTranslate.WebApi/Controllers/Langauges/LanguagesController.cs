using CompanyTranslate.Application.Services.Languages;
﻿using CompanyTranslate.Application.Configurations;
using CompanyTranslate.WebApi.Controllers.Langauges.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CompanyTranslate.WebApi.Controllers.Langauges;

[Controller]
[Route("/api/v1/languages")]
public class LanguagesController(ILanguageService service) : ControllerBase
{
	[HttpGet]
	public IActionResult Get([FromQuery]bool? isAvailable)
	{
		var result = service.GetLanguages(isAvailable);
		
		return Ok(result);
	}
}