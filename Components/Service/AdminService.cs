using BlazorApp.Components.Bd;
using BlazorApp.Components.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace BlazorApp.Components.Service
{

  public class AdminService
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;
    private IDbContextFactory<AppDbContext> _cont;


    public AdminService(AppDbContext context, IHttpContextAccessor httpContextAccessor, IDbContextFactory<AppDbContext> cont)
    {
      _context = context;
      _httpContextAccessor = httpContextAccessor;
      _cont = cont;
    }

    public async Task<List<Reponse>> Getrp()
    {
      return await _context.Reponses.Where(p => p.IsApprouved == false).ToListAsync();
    }

    public async Task<List<Fournisseur>> Getfsr()
    {
      return await _context.Fournisseurs.Where(p => p.IsApprouved == false).ToListAsync();
    }

    public async Task<List<Client>> Getclt()
    {
      return await _context.Clients.Where(p => p.IsApprouved == false).ToListAsync();
    }
    public async Task<List<AO>> GetAoffres()
    {
      return await _context.Aoffres.Where(p => p.IsApprouved == false).ToListAsync();
    }

    public async Task Updatefsr(Fournisseur fsr)
    {
      _context.Entry(fsr).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAoffre(AO ao)
    {
      _context.Entry(ao).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task UpdateClient(Client cl)
    {
      _context.Entry(cl).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task Updaterep(Reponse rp)
    {
      _context.Entry(rp).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }


    public async Task AddMessage(Notification nfc)
    {
      _context.Notifications.Add(nfc);
      await _context.SaveChangesAsync();
    }

    public async Task DelReponse(Reponse reponse)
    {
      _context.Reponses.Remove(reponse);
      await _context.SaveChangesAsync();
    }

    public async Task DelAo(AO ao)
    {
      _context.Aoffres.Remove(ao);
      await _context.SaveChangesAsync();
    }
    public async Task DelClient(Client clt)
    {
      _context.Clients.Remove(clt);
      await _context.SaveChangesAsync();
    }
    public async Task DelFournisseur(Fournisseur fsr)
    {
      _context.Fournisseurs.Remove(fsr);
      await _context.SaveChangesAsync();
    }

    public async Task<int> GetCltCash()
    {
      using (var context = _cont.CreateDbContext())
      {
        var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        List<Client> clts = await context.Clients.Where(c => c.DatePayment >= startOfMonth).ToListAsync();
        var x = 0;
        foreach (Client clt in clts)
        {
          var dt = clt.Payment - clt.DatePayment;
          if (dt.TotalDays == 30)
          {
            x = x + 10;
          }
          else if (dt.TotalDays == 182)
          {
            x = x + 50;
          }
          else if (dt.TotalDays == 365)
          {
            x = x + 80;
          }
        }
        return x;
      }
    }

    public async Task<int> GetFsrCash()
    {
      using (var context = _cont.CreateDbContext())
      {
        var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        List<Fournisseur> fsrs = await context.Fournisseurs.Where(c => c.DatePayment >= startOfMonth).ToListAsync();
        var x = 0;
        foreach (Fournisseur fsr in fsrs)
        {
          var dt = fsr.Payment - fsr.DatePayment;
          Console.WriteLine("yes" + dt.TotalDays);
          if (dt.TotalDays == 30)
          {
            x = x + 10;
          }
          else if (dt.TotalDays == 182)
          {
            x = x + 50;
          }
          else if (dt.TotalDays == 365)
          {
            x = x + 80;
          }
        }
        return x;
      }
    }

    public async Task<decimal> GetPrctClt()
    {
      using (var context = _cont.CreateDbContext())
      {
        var total = await context.Clients.CountAsync();
        var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var thismonth = await context.Clients.CountAsync(c => c.DateInscription >= startOfMonth);
        if (total == 0) return 0;
        return (thismonth / (decimal)total) * 100;
      }
    }

    public async Task<decimal> GetPrctFsr()
    {
      using (var context = _cont.CreateDbContext())
      {
        var total = await context.Fournisseurs.CountAsync();
        var startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        var thismonth = await context.Fournisseurs.CountAsync(c => c.DateInscription >= startOfMonth);
        if (total == 0) return 0;
        return (thismonth / (decimal)total) * 100;
      }
    }


  }
}