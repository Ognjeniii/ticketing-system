namespace ticketing_system.Models.Email
{
    public interface IEmailService
    {
        Task sendMailAsync(string emailTo, int generatedCode);
    }
}
