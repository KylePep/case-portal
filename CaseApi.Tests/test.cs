using RestSharp;

[TestFixture]
public class ApiTests
{
  [Test]
  public async Task GetCases_Returns200()
  {
    var client = new RestClient("http://localhost:5286");
    var request = new RestRequest("/api/case");

    var response = await client.ExecuteAsync(request);

    Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
  }
}