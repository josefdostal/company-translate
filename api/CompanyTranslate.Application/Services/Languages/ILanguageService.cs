using CompanyTranslate.Application.Dtos.Languages;

namespace CompanyTranslate.Application.Services.Languages;

public interface ILanguageService
{
	List<LanguageDto> GetLanguages(bool? isAvailable = null);
}