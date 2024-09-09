using FluentValidation;
using FluentValidation.AspNetCore;
using HsptMS.Abstraction;
using HsptMS.Data.Models;
using HsptMS.Services;
using HsptMS.Servise;
using HsptMS.Servises;
using HsptMS.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

public class Program
{
    private static string AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;

    private const string _connectionString = "Server=.;Database=HMS;Trusted_Connection=True;TrustServerCertificate=True;";

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register DbContext with connection string
        builder.Services.AddDbContext<HmsContext>(options =>
            options.UseSqlServer(_connectionString));

        builder.Services.AddScoped<IValidator<Patient>, PatientValidator>();

        builder.Services.AddScoped<IPatientService, PatientService>();
        builder.Services.AddScoped<IDoctorServise, DoctorServise>();
        builder.Services.AddScoped<IAppoinmentServises, AppoinmentServises>();
        builder.Services.AddScoped<IDepartmentServise, DepartmentServise>();
        builder.Services.AddScoped<IBillingService, BillingService>();
        builder.Services.AddScoped<IMasterService, MasterService>();
        builder.Services.AddScoped<IUserService, UsersService>();
        builder.Services.AddScoped<IConfigurationService, ConfigurationService>();
        builder.Services.AddScoped<IContextService, ContextService>();
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        builder.Services.AddTransient<EmailService>();

        // Fluent Validation configuration
        builder.Services.AddControllersWithViews()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<PatientValidator>());

        // HttpContext Accessor
        builder.Services.AddHttpContextAccessor();

        // Cookie-based Authentication
        builder.Services.AddAuthentication(AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Authentication/Login";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            });

        var app = builder.Build();

        // Exception handling
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Middleware for HTTP and static files
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        // Routing, Authentication, and Authorization
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        // Default Route Mapping
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
