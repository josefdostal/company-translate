using CompanyTranslate.Application.Configurations;
using CompanyTranslate.Application.Dtos.Languages;
using Microsoft.Extensions.Options;

namespace CompanyTranslate.Application.Services.Languages;

public class LanguageService(IOptions<CompanyTranslateConfiguration> config) : ILanguageService
{
	public List<LanguageDto> GetLanguages(bool? isAvailable = null)
	{
		var result = SupportedLangauge.All
		             .Select(x => new LanguageDto(x.Code, x.Name, config.Value.AvailableLanguages.Contains(x.Code)))
		             .ToList();
		
		if(isAvailable != null)
			result.RemoveAll(x => x.IsAvailable != isAvailable);

		return result;
	}
}