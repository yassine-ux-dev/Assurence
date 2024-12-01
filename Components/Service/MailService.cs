using System.Net;
using System.Net.Mail;
public class MailService()
{
  public string SendEmail(string email, string dettail)
  {
    string msg;
    try
    {
      using (MailMessage mail = new MailMessage())
      {
        mail.From = new MailAddress("benammara959@gmail.com");
        mail.To.Add(email);
        mail.Subject = "AssurencePfe";
        mail.Body = dettail;

        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
        {
          smtp.Credentials = new NetworkCredential("benammara959@gmail.com", "olqq tqcq glzn yfev");
          smtp.EnableSsl = true;
          smtp.Send(mail);
        }
      }
      msg = "sent succefully";
    }
    catch (Exception ex)
    {
      msg = ex.Message;
    }
    return msg;
  }
}