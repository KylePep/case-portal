using CaseApi.Data;
using CaseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseApi.Services;

public class CaseService
{
  private readonly AppDbContext _db;

  public CaseService(AppDbContext db) => _db = db;

  public async Task<List<Case>> GetAllCases() => await _db.Cases.ToListAsync();
  public async Task<Case?> GetCaseById(int id) => await _db.Cases.FindAsync(id);
  public async Task<Case> AddCase(Case c)
  {
    _db.Cases.Add(c);
    await _db.SaveChangesAsync();
    return c;
  }
}