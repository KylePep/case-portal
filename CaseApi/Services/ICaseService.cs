
using CaseApi.Models;

public interface ICaseService
{
  Task<List<Case>> GetAllCases();
  Task<Case?> GetCaseById(int id);
  Task<Case> AddCase(Case c);
}