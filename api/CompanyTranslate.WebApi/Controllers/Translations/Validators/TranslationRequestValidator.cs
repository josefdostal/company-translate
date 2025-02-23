using CompanyTranslate.WebApi.Controllers.Translations.Models;
using FluentValidation;

namespace CompanyTranslate.WebApi.Controllers.Translations.Validators;

public class TranslationRequestValidator : AbstractValidator<TranslationRequest>
{
	public TranslationRequestValidator()
	{
		RuleFor(x => x.Text).NotEmpty();
		RuleFor(x => x.SourceLanguage).NotEmpty();
		RuleFor(x => x.TargetLanguage).NotEmpty();
	}
}