namespace ticketing_system.Classes.Email
{
    public interface IEmailService
    {
        Task sendMailAsync(string emailTo, int generatedCode);
    }
}
