using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Components.Model
{
  public class Client
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom est requis")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Le nom doit contenir uniquement des caractères alphabétiques.")]
    [MinLength(3, ErrorMessage = "Le nom doit comporter au moins 3 caractères.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Le téléphone est requis.")]
    [RegularExpression(@"^[0-9]+$")]
    [Length(8, 8, ErrorMessage = "Le téléphone doit contenir 8 numéros")]
    public string Phone { get; set; }
    public string EmailId { get; set; }

    [Required(ErrorMessage = "Mot de passe requis.")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$", ErrorMessage = "Mot de passe : min. 6 caractères, incluant au moins 1 chiffre, 1 minuscule et 1 majuscule")]
    public string Password { get; set; }
    public bool IsApprouved { get; set; } = false;

    public DateTime Payment { get; set; } = DateTime.Today.AddDays(-1);
    public DateTime DatePayment { get; set; } = DateTime.Today.AddDays(-1);

    public DateTime DateInscription { get; set; } = DateTime.Today;



  }
}