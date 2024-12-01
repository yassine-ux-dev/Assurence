namespace BlazorApp.Components.Model
{
  public class CheckoutModel
  {
    public string paypalClientId { get; set; } = "";
    private string PaypalSecret { get; set; } = "";
    private string PaypalUrl { get; set; } = "";

    public CheckoutModel(IConfiguration configuration)
    {
      paypalClientId = configuration["PaypalSettings:ClientId"]!;
      PaypalSecret = configuration["PaypalSettings:Secret"]!;
      PaypalUrl = configuration["PaypalSettings:URL"]!;

    }
    public void OnGet()
    {

    }


  }
}