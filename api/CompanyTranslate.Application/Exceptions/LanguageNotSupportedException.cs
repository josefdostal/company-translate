namespace CompanyTranslate.Application.Exceptions;

public class LanguageNotSupportedException : Exception
{
	public LanguageNotSupportedException() { }

	public LanguageNotSupportedException(string message) : base(message) { }
}