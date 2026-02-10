namespace MvcWeb.Application;

public interface IEmailService
{
    void SendEmail(string message,string email);
}