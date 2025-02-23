using System.Net;
using System.Net.Http.Json;
using CompanyTranslate.Domain.Entities.Translations;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Exceptions;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Models;
using Newtonsoft.Json;

namespace CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate;

public class LibreTranslateClient(HttpClient httpClient) : ILibreTranslateClient
{
	public async Task<TranslationResponse> TranslateAsync(TranslationRequest request, CancellationToken cancellationToken = default)
	{
		var json = JsonConvert.SerializeObject(request);
		using var content = new StringContent(json);
		
		var message = new HttpRequestMessage(HttpMethod.Post, "translate")
		              {
			              Content = content
		              };
		var response = await httpClient.SendAsync(message, cancellationToken);
		
		if(response.StatusCode == HttpStatusCode.BadRequest)
			throw new LanguageNotSupportedException("A given language is not supported");
		
		response.EnsureSuccessStatusCode(); 
		
		var result = await response.Content.ReadFromJsonAsync<TranslationResponse>(cancellationToken);
		
		if (result is null)
			throw new NullReferenceException("Response from LibreTranslate is null");

		return result;
	}
}