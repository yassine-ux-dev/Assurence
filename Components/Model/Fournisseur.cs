using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Components.Model
{
  public class Fournisseur
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only alphabetic characters.")]
    [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Phone is required.")]
    [RegularExpression(@"^[0-9]+$")]
    [Length(8, 8, ErrorMessage = "Phone must contain 8 number")]
    public string Phone { get; set; }
    public string EmailId { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain at least one digit, one lowercase letter, and one uppercase letter.")]
    public string Password { get; set; }
    public bool IsApprouved { get; set; } = false;
    public DateTime Payment { get; set; } = DateTime.Today.AddDays(-1);
    public DateTime DatePayment { get; set; } = DateTime.Today.AddDays(-1);

    public DateTime DateInscription { get; set; } = DateTime.Today;
  }
}