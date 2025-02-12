using System.Net;
using System.Net.Http.Json;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Models;
using Moq;
using Newtonsoft.Json;

namespace CompanyTranslate.Infrastructure.Unit.ExternalAPIs.LibreTranslate.Services;

public class LibreTranslateUnit
{
	private readonly Mock<HttpClient> _httpClientM;
	private readonly LibreTranslateClient _client;
	
	public LibreTranslateUnit()
	{
		_httpClientM = new Mock<HttpClient>();
		_client = new LibreTranslateClient(_httpClientM.Object);
	}
	
	[Fact]
	public async Task Translate()
	{
		// Arrange
		var payload = new TranslationRequest("test", "cs", "en");
		var responsePayload = new TranslationResponse("test_translated", ["alternative1", "alternative2"]);
		
		var responseContent = JsonContent.Create(responsePayload);

		var response = new HttpResponseMessage()
		               {
			               Content = responseContent,
		               };

		_httpClientM.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

		// Act
		var result = await _client.TranslateAsync(payload);
		
		// Assert
		Assert.NotNull(result);
		Assert.Equivalent(responsePayload, result);
	}
	
	[Fact]
	public async Task Translate_NotFound()
	{
		// Arrange
		var payload = new TranslationRequest("test", "cs", "en");
		

		var response = new HttpResponseMessage();
		response.StatusCode = HttpStatusCode.NotFound;

		_httpClientM.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

		// Act / Assert
		await Assert.ThrowsAsync<HttpRequestException>(async () => await _client.TranslateAsync(payload));
	}
}