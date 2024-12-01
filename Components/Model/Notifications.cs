using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Components.Model
{
  public class Notification
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string Nfc { get; set; }
    public DateTime Date { get; set; }

  }
}