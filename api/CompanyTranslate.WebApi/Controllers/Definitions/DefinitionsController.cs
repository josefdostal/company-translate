using Microsoft.AspNetCore.Mvc;

namespace CompanyTranslate.WebApi.Controllers.Definitions;

[Controller]
[Route("api/v1/definitions")]
public class DefinitionsController : Controller
{
	[HttpGet]
	[Route("{phrase}")]
	public async Task<IActionResult> GetAsync(string phrase, CancellationToken ct)
	{
		if(phrase == "hello")
			return Json(new
			          {
				        Foo = "ahoj"  
			          });
		return NotFound();
	}
}