namespace MvcWeb.Application;

// خدمة لإرسال الإيميلات
public class EmailService : IEmailService
{
    public void SendEmail(string message,string email)
    {
        Console.WriteLine($"Send Email to {email}: {message}");
    }
}
