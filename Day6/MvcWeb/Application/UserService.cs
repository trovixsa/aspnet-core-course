namespace MvcWeb.Application;

// خدمة المستخدم التي تعتمد على EmailService
public class UserService
{
    private EmailService _emailService;

    public UserService()
    {
        // المشكلة: نقوم بإنشاء الكائن هنا مباشرة
        _emailService = new EmailService();
    }

    public void RegisterUser(string username)
    {
        // تسجيل المستخدم
        Console.WriteLine($"{username} is created in database");

        // إرسال إيميل ترحيبي
        _emailService.SendEmail($"Welcome {username} in asp.net core course",username);
    }
}

