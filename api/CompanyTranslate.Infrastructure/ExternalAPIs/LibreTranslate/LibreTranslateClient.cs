using System.Net.Http.Json;
using CompanyTranslate.Domain.Entities.Translations;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Models;

namespace CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate;

public class LibreTranslateClient(HttpClient httpClient) : ILibreTranslateClient
{
	public async Task<TranslationResponse> TranslateAsync(TranslationRequest request, CancellationToken cancellationToken = default)
	{
		var content = JsonContent.Create(request);
		var message = new HttpRequestMessage(HttpMethod.Post, "translate")
		              {
			              Content = content
		              };
		var response = await httpClient.SendAsync(message, cancellationToken);
		response.EnsureSuccessStatusCode(); 
		
		var result = await response.Content.ReadFromJsonAsync<TranslationResponse>(cancellationToken);
		
		if (result is null)
			throw new NullReferenceException("Response from LibreTranslate is null");

		return result;
	}
}