using ticketing_system.DTO;
using Microsoft.EntityFrameworkCore;
using ticketing_system.Models.Ticket.Repository.Implementation;
using ticketing_system.Models.Ticket.Services.Abstraction;
using ticketing_system.Models.Ticket.Services.Implementation;
using ticketing_system.Models.Ticket.Repository.Abstraction;
using ticketing_system.Models.User.Repositories.Abstraction;
using ticketing_system.Models.User.Repositories.Implementation;
using ticketing_system.Models.User.Services.Abstraction;
using ticketing_system.Models.User.Services.Implementation;
using ticketing_system.Classes.Email;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews()
            .AddSessionStateTempDataProvider();

        builder.Services.AddRazorPages()
            .AddSessionStateTempDataProvider();

        // ef core
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        // dependency injection
        builder.Services.AddScoped<ITicketRepository, TicketRepository>();
        builder.Services.AddScoped<ITicketService, TicketService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IEmailService, EmailService>();

        builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
        

        // sesije
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            // sesija se postavlja da traje 3 minuta.
            options.IdleTimeout = TimeSpan.FromMinutes(10);
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.SameSite = SameSiteMode.Strict;
            options.Cookie.HttpOnly = true;
            // options.Cookie.IsEssential = true; 
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Base/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();

        // za slike
        app.UseStaticFiles();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Base}/{action=Index}/{id?}");

        app.Run();
    }
}