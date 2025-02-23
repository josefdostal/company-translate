namespace CompanyTranslate.Infrastructure.ExternalAPIs.LibreTranslate.Exceptions;

public class LanguageNotSupportedException : Exception
{
	public LanguageNotSupportedException() { }

	public LanguageNotSupportedException(string message) : base(message) { }
}