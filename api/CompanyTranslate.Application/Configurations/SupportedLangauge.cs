namespace CompanyTranslate.Application.Configurations;

public class SupportedLangauge(string Code, string Name)
{
	public string Code { get; } = Code;
	public string Name { get; } = Name;
	
	public static SupportedLangauge Czech = new("cs", "Czech");
	public static SupportedLangauge English = new("en", "English");
	public static SupportedLangauge French = new("fr", "French");
	public static List<SupportedLangauge> All = new() { Czech, English, French };
}