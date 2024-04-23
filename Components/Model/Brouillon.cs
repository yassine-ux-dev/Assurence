using System;
namespace BlazorApp.Components.Model
{
  public class Brouillon
  {

    public int Id { get; set; }
    public string Titre { get; set; }
    public string EmailA { get; set; }
    public string Description { get; set; }
    public DateTime DateDemande { get; set; }
    public DateTime DelaisR { get; set; }
    public string Adress { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public byte[] Document { get; set; }



  }
}