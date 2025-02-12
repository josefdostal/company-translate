using System.Net;
using System.Net.Http.Json;
using CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Dtos;
using Moq;
using Newtonsoft.Json;

namespace CompanyTranslate.Infrastructure.Unit.ExternalAPIs.LibreTranslate.Services;

public class LibreTranslateUnit
{
	public Mock<HttpClient> ClientM { get; }
	public Infrastructure.ExternalAPIs.LibreTranslate.Services.LibreTranslate Subject { get; }
	
	public LibreTranslateUnit()
	{
		ClientM = new Mock<HttpClient>();
		Subject = new Infrastructure.ExternalAPIs.LibreTranslate.Services.LibreTranslate(ClientM.Object);
	}
	
	[Fact]
	public async Task Translate()
	{
		// Arrange
		var payload = new TranslationRequest("test", "cs", "en");
		var responsePayload = new TranslationResponse
		                      {
			                      TranslatedText = "test_translated",
			                      Alternatives = ["alternative1", "alternative2"],
		                      };
		
		var responseContent = JsonContent.Create(responsePayload);

		var response = new HttpResponseMessage()
		               {
			               Content = responseContent,
		               };

		ClientM.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

		// Act
		var result = await Subject.TranslateAsync(payload);
		
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

		ClientM.Setup(x => x.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<CancellationToken>())).ReturnsAsync(response);

		// Act / Assert
		await Assert.ThrowsAsync<HttpRequestException>(async () => await Subject.TranslateAsync(payload));
	}
}