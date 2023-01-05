using System.Xml;
using ConsoleApp;

Console.WriteLine("----Newsfeed App----");

// List of RSS feed URIs
const string microsoftDevBlogsUri = "https://devblogs.microsoft.com/dotnet/feed/";

// Get RSS feed content
var httpClient = new HttpClient();
HttpResponseMessage responseMessage = await httpClient.GetAsync(microsoftDevBlogsUri);

responseMessage.EnsureSuccessStatusCode();

var responseContent = await responseMessage.Content.ReadAsStringAsync();

// Parse the RSS feed content to an XML document
var xmlDocument = new XmlDocument();
xmlDocument.LoadXml(responseContent);

// Get data from the XML document
var articleService = new ArticleService();
IReadOnlyList<Article> articles = articleService.GetArticles(xmlDocument);

foreach (Article article in articles)
{
    Console.WriteLine($"Title: {article.Title}");
    Console.WriteLine($"Description: {article.Description}");
    Console.WriteLine($"Creator: {article.Creator}");
    Console.WriteLine($"Published: {article.PublishedDate}");
    Console.WriteLine($"Link: {article.Link}");

    Console.WriteLine();
}
