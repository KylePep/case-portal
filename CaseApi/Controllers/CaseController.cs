using System.Xml.Linq;
using CaseApi.Data;
using CaseApi.Models;
using CaseApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaseApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CaseController : ControllerBase
{
  private readonly AppDbContext _db;

  public CaseController(AppDbContext db)
  {
    _db = db;
  }
  [HttpGet("/")]
  public string Root() => "API is running!";

  [HttpGet]
  public IEnumerable<Case> Get()
  {
    return _db.Cases.ToList();
  }

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

  [HttpPost]
  public async Task<IActionResult> Post(Case c)
  {
    _db.Cases.Add(c);
    await _db.SaveChangesAsync();
    return Ok(c);
  }
}