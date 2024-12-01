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
    public async Task AddCo(DemoRequestModel ao)
    {
      await _context.Requestes.AddAsync(ao);
      await _context.SaveChangesAsync();
    }
    public async Task AddBr(Brouillon ao)
    {
      await _context.Brouillons.AddAsync(ao);
      await _context.SaveChangesAsync();
    }
    public async Task AddRp(Reponse reponse)
    {
      await _context.Reponses.AddAsync(reponse);
      await _context.SaveChangesAsync();
    }
    public async Task DelReponse(Reponse reponse)
    {
      _context.Reponses.Remove(reponse);
      await _context.SaveChangesAsync();
    }
    public async Task DelBrouillon(Brouillon brouillon)
    {
      _context.Brouillons.Remove(brouillon);
      await _context.SaveChangesAsync();
    }


    public async Task UpdateBr(Brouillon br)
    {
      _context.Entry(br).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
    public async Task<List<AO>> GetAo()
    {
      return await _context.Aoffres.ToListAsync();
    }
    public async Task<AO> GetaoffreById(int Id)
    {
      return await _context.Aoffres.FirstOrDefaultAsync(p => p.Id == Id);
    }
    public Brouillon GetBrbyId(int Id)
    {
      return _context.Brouillons.FirstOrDefault(p => p.Id == Id);
    }

    public async Task<List<Reponse>> GetReponses(int idao)
    {
      return await _context.Reponses.Where(p => p.IdAoffre == idao).ToListAsync();
    }
    public async Task<Reponse> GetReponse(int idao)
    {
      return await _context.Reponses.FirstOrDefaultAsync(p => p.Id == idao);
    }

    public async Task<List<Brouillon>> Getbrouillans(string Email)
    {
      return await _context.Brouillons.Where(p => p.EmailA == Email).ToListAsync();
    }

    public async Task<List<AO>> GetAoffresencours(string Email)
    {
      return await _context.Aoffres.Where(p => p.EmailA == Email && p.DelaisR > DateTime.Now).ToListAsync();
    }
    public async Task<List<AO>> GetAoffresArchive(string Email)
    {
      return await _context.Aoffres.Where(p => p.EmailA == Email && p.DelaisR < DateTime.Now).ToListAsync();
    }
    public async Task<List<string>> GetRelations(string Email)
    {
      return await (from ao in _context.Aoffres
                    join reponse in _context.Reponses on ao.Id equals reponse.IdAoffre
                    join fournisseur in _context.Fournisseurs on reponse.IdFournisseur equals fournisseur.Id
                    where ao.EmailA == Email && reponse.IsApprouved == true
                    select fournisseur.EmailId).ToListAsync();
    }


  }
}