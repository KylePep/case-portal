namespace CaseApi.Tests;

using CaseApi.Data;
using CaseApi.Models;
using CaseApi.Services;
using Microsoft.EntityFrameworkCore;
using RestSharp;

[TestFixture]
public class CaseTests
{
  private AppDbContext _db;
  private CaseService _service;

  [SetUp]
  public void Setup()
  {
    var options = new DbContextOptionsBuilder<AppDbContext>()
      .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
      .Options;
    _db = new AppDbContext(options);
    _service = new CaseService(_db);
  }

  [TearDown]
  public void TearDown()
  {
    _db.Dispose();
  }

  [Test]
  public async Task GetCases_Returns200()
  {
    var client = new RestClient("http://localhost:5286");
    var request = new RestRequest("/api/case");

    var response = await client.ExecuteAsync(request);

    Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
  }

  [Test]
  public async Task AddCase_should_Add_Case()
  {
    var c = new Case { Title = "Test Case", Status = "Open" };
    var result = await _service.AddCase(c);

    Assert.IsNotNull(result);
    Assert.That(result.Title, Is.EqualTo("Test Case"));
    Assert.That(_db.Cases.Count(), Is.EqualTo(1));
  }

  [Test]
  public async Task GetAllCases_Should_Return_all()
  {
    _db.Cases.Add(new Case { Title = "A", Status = "Open" });
    _db.Cases.Add(new Case { Title = "B", Status = "Closed" });
    await _db.SaveChangesAsync();

    var result = await _service.GetAllCases();
    Assert.That(result.Count(), Is.EqualTo(2));
  }

  [Test]
  public async Task GetCaseById_Should_Return_Correct_Case()
  {
    var c = new Case { Title = "FindMe", Status = "Open" };
    _db.Cases.Add(c);
    await _db.SaveChangesAsync();

    var result = await _service.GetCaseById(c.Id);
    Assert.IsNotNull(result);
    Assert.That(result?.Title, Is.EqualTo("FindMe"));
  }

}