using BalazorRealtimeCharts.Server.Hubs;
using BalazorRealtimeCharts.Server.Providers;

namespace balazor_realtime_charts;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(policy =>
        {
            policy.AddPolicy("CorsPolicy", option => option
                .WithOrigins("https://localhost:7114")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());
        });

        builder.Services.AddSignalR();
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages();
        builder.Services.AddScoped<TimeWatcher>();


        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCors("CorsPolicy");
        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapRazorPages();
        app.MapControllers();
        app.MapHub<ChartHub>("/chartdata");
        app.MapFallbackToFile("index.html");
        app.Run();
    }
}