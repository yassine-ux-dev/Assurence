using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Components.Model
{
  public class Admin
  {
    public int Id { get; set; }
    public string EmailId { get; set; }


    public string Password { get; set; }
  }
}