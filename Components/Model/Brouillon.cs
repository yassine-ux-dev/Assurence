using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Components.Model
{
  public class Brouillon
  {
    public int Id { get; set; }

    public string Titre { get; set; }
    public string EmailA { get; set; }

    public string Description { get; set; }

    public DateTime DateDemande { get; set; }

    public string Adress { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Entrer budget valide")]
    public int Budget { get; set; }

    [FutureDate(ErrorMessage = "Delais de repons doit étre 15 jour superieure au date d'aujourd'hui au minimum")]
    public DateTime DelaisR { get; set; } = DateTime.Today.AddDays(15);






  }

  public class FutureDateAttribute : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      if (value != null)
      {
        DateTime delaisR = (DateTime)value;
        if (delaisR < DateTime.Today.AddDays(15))
        {
          return new ValidationResult(ErrorMessage);
        }
      }
      return ValidationResult.Success;
    }
  }
}