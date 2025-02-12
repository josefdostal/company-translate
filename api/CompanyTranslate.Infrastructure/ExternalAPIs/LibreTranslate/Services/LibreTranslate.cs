using System.Net.Http.Json;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Dtos;
using Newtonsoft.Json;

namespace CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Services;

public class LibreTranslate(HttpClient httpClient)
{
	public async Task<TranslationResult> TranslateAsync(TranslationRequest request, CancellationToken cancellationToken = default)
	{
		var content = JsonContent.Create(request);
		var message = new HttpRequestMessage(HttpMethod.Post, "translate")
		              {
			              Content = content
		              };
		
		var response = await httpClient.SendAsync(message, cancellationToken);
		response.EnsureSuccessStatusCode(); 
		
		var json = await response.Content.ReadAsStringAsync(cancellationToken);
		var result = JsonConvert.DeserializeObject<TranslationResult>(json);
		if (result is null)
			throw new NullReferenceException("Response from LibreTranslate is null");

		return result;
	}
}