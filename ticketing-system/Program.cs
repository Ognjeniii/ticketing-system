using ticketing_system.DTO;
using Microsoft.EntityFrameworkCore;
using ticketing_system.Models.Ticket.Repository.Implementation;
using ticketing_system.Models.Ticket.Services.Abstraction;
using ticketing_system.Models.Ticket.Services.Implementation;
using ticketing_system.Models.Ticket.Repository.Abstraction;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // ef core
        builder.Services.AddDbContext<ApplicationDbContext>(options =>  
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // dependency injection
        builder.Services.AddScoped<ITicketRepository, TicketRepository>();
        builder.Services.AddScoped<ITicketService, TicketService>();

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

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Base}/{action=Index}/{id?}");

        app.Run();
    }
}