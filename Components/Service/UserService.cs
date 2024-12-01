using BlazorApp.Components.Bd;
using BlazorApp.Components.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Components.Service
{
  public class UserService
  {
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _context;

    public UserService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
    {
      _context = context;
      _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Client> GetClient(string emailId)
    {
      return await _context.Clients.FirstOrDefaultAsync(p => p.EmailId == emailId);
    }

    public async Task<Fournisseur> GetFournisseur(string emailId)
    {
      return await _context.Fournisseurs.FirstOrDefaultAsync(p => p.EmailId == emailId);
    }

    public async Task<List<Notification>> GetNotifications(string emailId)
    {
      return await _context.Notifications.Where(p => p.Email == emailId).ToListAsync();
    }
    public async Task<Fournisseur> GetFournisseurbyId(int? Id)
    {
      return await _context.Fournisseurs.FirstOrDefaultAsync(p => p.Id == Id);
    }

    public async Task AddFournisseur(Fournisseur user)
    {
      await _context.Fournisseurs.AddAsync(user);
      await _context.SaveChangesAsync();
    }

    public async Task AddClient(Client user)
    {
      await _context.Clients.AddAsync(user);
      await _context.SaveChangesAsync();
    }

    public void SetEmailIdInCookie(string EmailId)
    {
      _httpContextAccessor.HttpContext.Response.Cookies.Append("EmailId", EmailId);
    }

    public void SetRoleInCookie(string Role)
    {
      _httpContextAccessor.HttpContext.Response.Cookies.Append("Role", Role);
    }


    public string GetEmailIdFromCookie()
    {
      return _httpContextAccessor.HttpContext.Request.Cookies["EmailId"];
    }

    public string GetRoleFromCookie()
    {
      return _httpContextAccessor.HttpContext.Request.Cookies["Role"];
    }


    public void DeleteEmailIdCookie()
    {
      _httpContextAccessor.HttpContext.Response.Cookies.Delete("EmailId");
    }

    public void DeleteRoleCookie()
    {
      _httpContextAccessor.HttpContext.Response.Cookies.Delete("Role");
    }




    public bool IsAuthenticated()
    {
      return !string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Cookies["EmailId"]);
    }

    public async Task UpdateFournisseur(Fournisseur fsr)
    {
      _context.Entry(fsr).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task UpdateClient(Client clt)
    {
      _context.Entry(clt).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
    public async Task<bool> IsPayed(string mail)
    {

      if (await GetClient(mail) != null)
      {
        return ((await GetClient(mail)).Payment > DateTime.Now);
      }
      else if (await GetFournisseur(mail) != null)
      {
        return ((await GetFournisseur(mail)).Payment > DateTime.Now);
      }
      return true;
    }


  }

}
