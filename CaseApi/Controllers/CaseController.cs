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
  private readonly ICaseService _service;

  public CaseController(ICaseService service)
  {
    _service = service;
  }

  [HttpGet]
  public async Task<IEnumerable<Case>> Get()
  {
    return await _service.GetAllCases();
  }

  [HttpPost]
  public async Task<IActionResult> Post(Case c)
  {
    var result = await _service.AddCase(c);
    return Ok(result);
  }
}