namespace ConsoleLibrary.Model;

internal class LocalizedBook : Book
{
    public string CountryOfLocalization { get; set; }

    public string LocalPublisher { get; set; }
}
