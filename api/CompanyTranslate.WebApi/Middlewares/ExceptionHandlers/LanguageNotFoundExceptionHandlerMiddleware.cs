using System.Net;
using CompanyTranslate.Application.Exceptions;
using Newtonsoft.Json;

namespace CompanyTranslate.WebApi.Middlewares.ExceptionHandlers;

public class LanguageNotFoundExceptionHandlerMiddleware(RequestDelegate next)
{
	public async Task Invoke(HttpContext context)
	{
		try
		{
			await next(context);
		}
		catch(LanguageNotSupportedException ex)
		{
			context.Response.Clear();
			context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
			var message = new ErrorModel(ex.Message);
			var json = JsonConvert.SerializeObject(message);
			
			await context.Response.WriteAsync(json);
		}
	}
}