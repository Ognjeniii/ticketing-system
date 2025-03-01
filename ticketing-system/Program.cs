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
using ticketing_system.Models.Email;
using ticketing_system.Models.Ticket.Repositories.Abstraction;
using ticketing_system.Models.Ticket.Repositories.Implementation;
using ticketing_system.Models.Group.Repositories.Abstraction;
using ticketing_system.Models.Group.Repositories.Implementation;
using ticketing_system.Models.Group.Services.Abstraction;
using ticketing_system.Models.Group.Services.Implementation;
using ticketing_system.Filters;

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
        /* TICKETS */
        builder.Services.AddScoped<ITicketRepository, TicketRepository>();
        builder.Services.AddScoped<ITicketService, TicketService>();

        /* USER */
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

        /* EMAIL */
        builder.Services.AddScoped<IEmailService, EmailService>();

        /* URGENCY */
        builder.Services.AddScoped<IUrgencyRepository, UrgencyRepository>();
        builder.Services.AddScoped<IUrgencyService, UrgencyService>();

        /* TICKET TYPE */
        builder.Services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
        builder.Services.AddScoped<ITicketTypeService, TicketTypeService>();

        /* STATUS */
        builder.Services.AddScoped<IStatusRepository, StatusRepository>();
        builder.Services.AddScoped<IStatusService, StatusService>();

        /* GROUP */
        builder.Services.AddScoped<IGroupRepository, GroupRepository>();
        builder.Services.AddScoped<IGroupService, GroupService>();

        builder.Services.AddScoped<SessionAuthFilter>(); // registracija filtera

        builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

        builder.Services.Configure<Microsoft.AspNetCore.Http.Features.FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 20971520; // 104857600 - 100mb, current 20mb
        });
        

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


        builder.Services.AddControllersWithViews(options =>
        {
            options.Filters.Add<SessionAuthFilter>(); // Dodavanje globalne provere prijave
        });

        builder.Services.AddHttpContextAccessor();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
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
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}