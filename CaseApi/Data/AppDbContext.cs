using Microsoft.EntityFrameworkCore;
using CaseApi.Models;

namespace CaseApi.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public DbSet<Case> Cases => Set<Case>();
}
