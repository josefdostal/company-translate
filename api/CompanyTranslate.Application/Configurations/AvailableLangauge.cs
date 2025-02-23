namespace CompanyTranslate.Application.Configurations;

public class AvailableLangauge(string Code, string Name)
{
	public static AvailableLangauge Czech = new("cs", "Czech");
	public static AvailableLangauge English = new("en", "English");
	public static AvailableLangauge French = new("fr", "French");
	public static List<AvailableLangauge> All = new() { Czech, English, French };
}