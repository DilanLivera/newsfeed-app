using System.Xml;

namespace ConsoleApp;

internal sealed class ArticleService
{
    internal IReadOnlyList<Article> GetArticles(XmlDocument xmlDocument)
    {
        var articles = new List<Article>();
        XmlNodeList items = xmlDocument.GetElementsByTagName("item");

        foreach (XmlNode itemNode in items)
        {
            Article article = GetArticle(itemNode);
            articles.Add(article);
        }

        return articles.AsReadOnly();
    }

    private Article GetArticle(XmlNode node)
    {
        var article = new Article();

        foreach (XmlNode childNode in node.ChildNodes)
        {
            switch (childNode.Name)
            {
                case "title":
                    article.Title = childNode.InnerXml;
                    break;
                case "description":
                    article.Description = childNode.InnerXml;
                    break;
                case "dc:creator":
                    article.Creator = childNode.InnerXml;
                    break;
                case "pubDate":
                    article.PublishedDate = childNode.InnerXml;
                    break;
                case "link":
                    article.Link = childNode.InnerXml;
                    break;
            }
        }

        return article;
    }
}
