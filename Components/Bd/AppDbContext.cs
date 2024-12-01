
using BlazorApp.Components.Model;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace BlazorApp.Components.Bd
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext>
    options) : base(options)

    {

    }


    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<Fournisseur> Fournisseurs => Set<Fournisseur>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<AO> Aoffres => Set<AO>();
    public DbSet<Brouillon> Brouillons => Set<Brouillon>();
    public DbSet<Reponse> Reponses => Set<Reponse>();
    public DbSet<DemoRequestModel> Requestes => Set<DemoRequestModel>();

    public DbSet<Notification> Notifications => Set<Notification>();



  }

}