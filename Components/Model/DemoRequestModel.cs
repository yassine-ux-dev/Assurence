using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Components.Model
{
  public class DemoRequestModel
  {
    public int Id { get; set; }
    public string FirstName { get; set; }


    public string Email { get; set; }


    public string Comment { get; set; }
  }
}