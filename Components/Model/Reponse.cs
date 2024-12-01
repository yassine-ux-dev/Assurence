using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Components.Model
{
  public class Reponse
  {
    public int Id { get; set; }
    public int? IdFournisseur { get; set; }
    public int? IdAoffre { get; set; }

    public string Dettail { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Entrer budget valide")]
    public int PrixProp { get; set; }
    public DateTime DateSaisie { get; set; }
    public bool IsApprouved { get; set; } = false;

  }
}