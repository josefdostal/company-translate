using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Models;

namespace CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate;

public interface ILibreTranslatorClient
{
	Task<TranslationResponse> TranslateAsync(TranslationRequest request, CancellationToken cancellationToken = default);
}