using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Components.Model;
using BlazorApp.Components.Bd;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Components.Service
{
  public class AoService
  {
    private readonly AppDbContext _context;

    public AoService(AppDbContext context)
    {
      _context = context;
    }

    public async Task AddAo(AO ao)
    {
      await _context.Aoffres.AddAsync(ao);
      await _context.SaveChangesAsync();
    }

    public async Task<List<AO>> GetAo()
    {
      return await _context.Aoffres.ToListAsync();
    }
    public async Task<List<Brouillon>> GetBAo()
    {
      return await _context.Brouillons.ToListAsync();
    }
    public async Task<AO> GetaoffreById(int Id)
    {
      return await _context.Aoffres.FirstOrDefaultAsync(p => p.Id == Id);
    }


  }

}