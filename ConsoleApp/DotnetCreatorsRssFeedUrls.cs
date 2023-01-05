namespace ConsoleApp;

public sealed class DotnetCreatorsRssFeedUrls
{
    public DotnetCreatorsRssFeedUrls()
    {
        Urls = new Dictionary<string, string>
        {
            { ".NET Microsoft Channels", "https://devblogs.microsoft.com/dotnet/feed" },
            { "Andrew Lock", "https://andrewlock.net/rss.xml" },
            { "Code Maze", "https://code-maze.com/feed" },
            { "Dan Clarke", "https://www.danclarke.com/rss" },
            { "Derek Comartin", "https://codeopinion.com/feed" },
            { "Jimmy Bogard", "https://jimmybogard.com/rss" },
            { "Kevin Gosse", "https://medium.com/feed/@kevingosse" },
            { "Khalid Abuhakmeh", "https://khalidabuhakmeh.com/feed.xml" }
        };
    }

    public Dictionary<string, string> Urls { get; }
}
