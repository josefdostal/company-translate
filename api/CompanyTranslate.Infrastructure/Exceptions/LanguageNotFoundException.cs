namespace CompanyTranslate.Infrastructure.Exceptions;

public class LanguageNotFoundException : Exception
{
	public LanguageNotFoundException() { }

	public LanguageNotFoundException(string message) : base(message) { }
}