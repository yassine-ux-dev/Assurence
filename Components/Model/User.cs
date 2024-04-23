using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Components.Model
{
  public class User
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only alphabetic characters.")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
    public string Name { get; set; }

    public string EmailId { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    [StringLength(10, ErrorMessage = "Password must be between {2} and {1} characters.", MinimumLength = 6)]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain at least one digit, one lowercase letter, and one uppercase letter.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm password is required.")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; }
  }
}
