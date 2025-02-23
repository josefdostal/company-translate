using Microsoft.AspNetCore.Mvc;

namespace CompanyTranslate.WebApi.Controllers.Translations.Models;

public record TranslationRequest(
	[FromRoute(Name = "text")] string Text,
	[FromRoute(Name = "sourceLanguage")] string SourceLanguage,
	[FromRoute(Name = "targetLanguage")] string TargetLanguage);