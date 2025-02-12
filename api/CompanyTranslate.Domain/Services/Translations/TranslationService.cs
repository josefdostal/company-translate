using System.Reflection.PortableExecutable;
using CompanyTranslate.Domain.Entities.Translations;
using CompanyTranslate.Domain.Interfaces.Translations;

namespace CompanyTranslate.Domain.Services.Translations;

public class TranslationService(IEnumerable<ITranslator> translators) : ITranslationService
{
	public async Task<Translation?> TranslateAsync(string text, string sourceLanguage, string targetLanguage, CancellationToken cancellationToken = default)
	{
		foreach(var translator in translators)
		{
			var result = await translator.GetTranslationAsync(text, sourceLanguage, targetLanguage, cancellationToken);
			if(result == null)
				continue;

			return result;
		}
		return null;
	}
}