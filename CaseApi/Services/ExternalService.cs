namespace CaseApi.Services;

public class ExternalServices
{
  private readonly HttpClient _http;

  public ExternalServices(HttpClient http)
  {
    _http = http;
  }

  public async Task<string> GetExternalData()
  {
    var res = await _http.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
    return await res.Content.ReadAsStringAsync();
  }
}