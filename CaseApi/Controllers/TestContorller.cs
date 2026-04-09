using System.Xml.Linq;
using CaseApi.Data;
using CaseApi.Models;
using CaseApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaseApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
  private readonly AppDbContext _db;

  public TestController(AppDbContext db)
  {
    _db = db;
  }
  [HttpGet("/")]
  public string Root() => "API is running!";

  [HttpGet("external")]
  public async Task<string> External([FromServices] ExternalServices svc)
  {
    return await svc.GetExternalData();
  }

  [HttpGet("soap-test")]
  public string soapTest([FromServices] SoapService svc)
  {
    var xml = "<root><value>Hello</value></root>";
    return svc.ParseXmlResponse(xml);
  }
}