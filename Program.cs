using HsptMS.Abstraction;
using HsptMS.Servise;
using HsptMS.Servises;
using Microsoft.EntityFrameworkCore;



namespace YtMvc;

public class Program
{
    public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);



        builder.Services.AddScoped<IPatientService, PatientService>();

        builder.Services.AddTransient<IDoctorServise,DoctorServise>();
		builder.Services.AddTransient<IAppoinmentServises, AppoinmentServises>();
		builder.Services.AddTransient<IDepartmentServise,DepartmentServise>();

		builder.Services.AddControllersWithViews();

		var app = builder.Build();


        if (!app.Environment.IsDevelopment())
		{
			app.UseExceptionHandler("/Home/Error");

			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();

		app.UseAuthorization();

		app.MapControllerRoute(
			name: "default",
			pattern: "{controller=Home}/{action=Index}/{id?}");

		app.Run();
	}
}