using System.Xml;

Console.WriteLine("----Newsfeed App----");

const string microsoftDevBlogsUri = "https://devblogs.microsoft.com/dotnet/feed/";
var httpClient = new HttpClient();
HttpResponseMessage responseMessage = await httpClient.GetAsync(microsoftDevBlogsUri);

responseMessage.EnsureSuccessStatusCode();

var responseContent = await responseMessage.Content.ReadAsStringAsync();

var xmlDocument = new XmlDocument();
xmlDocument.LoadXml(responseContent);
XmlNodeList items = xmlDocument.GetElementsByTagName("item");

foreach (XmlNode itemNode in items)
{
    var title = "";
    var description = "";
    var creator = "";
    var publishedDate = "";
    var link = "";

    foreach (XmlNode childNode in itemNode.ChildNodes)
    {
        switch (childNode.Name)
        {
            case "title":
                title = childNode.InnerXml;
                break;
            case "description":
                description = childNode.InnerXml;
                break;
            case "dc:creator":
                creator = childNode.InnerXml;
                break;
            case "pubDate":
                publishedDate = childNode.InnerXml;
                break;
            case "link":
                link = childNode.InnerXml;
                break;
        }
    }

    Console.WriteLine($"Title: {title}");
    Console.WriteLine($"Description: {description}");
    Console.WriteLine($"Creator: {creator}");
    Console.WriteLine($"Published: {publishedDate}");
    Console.WriteLine($"Link: {link}");

    Console.WriteLine();
}
