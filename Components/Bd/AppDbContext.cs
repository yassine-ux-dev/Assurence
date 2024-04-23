
using BlazorApp.Components.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Components.Bd
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext>
    options) : base(options)

    {

    }



    public DbSet<User> Users => Set<User>();
    public DbSet<AO> Aoffres => Set<AO>();
    public DbSet<Brouillon> Brouillons => Set<Brouillon>();


  }

}