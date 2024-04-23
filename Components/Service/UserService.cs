
using BlazorApp.Components.Bd;
using BlazorApp.Components.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Components.Service
{
  public class UserService
  {
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
      _context = context;
    }

    public async Task<User> GetUserByMail(string EmailId)
    {
      return await _context.Users.FirstOrDefaultAsync(p => p.EmailId == EmailId);
    }
  }
}
