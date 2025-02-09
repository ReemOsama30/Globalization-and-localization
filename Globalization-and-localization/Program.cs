using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace Globalization_and_localization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddLocalization(options=>options.ResourcesPath="Resource");
            builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportCulture = new[] {
                 new CultureInfo("ar-EG"),
                 new CultureInfo("en")
                
                
                };
                options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
                options.SupportedCultures = supportCulture;
                options.SupportedUICultures = supportCulture;
                options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
            });

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
        var locOptions= app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
        
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
