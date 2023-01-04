Console.WriteLine("Newsfeed App");

const string microsoftDevBlogsUri = "https://devblogs.microsoft.com/dotnet/feed/";
var httpClient = new HttpClient();
HttpResponseMessage responseMessage = await httpClient.GetAsync(microsoftDevBlogsUri);

responseMessage.EnsureSuccessStatusCode();

var responseContent = await responseMessage.Content.ReadAsStringAsync();

Console.WriteLine(responseContent);
