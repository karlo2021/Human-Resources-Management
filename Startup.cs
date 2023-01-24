using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using IdentityApp.Services;

namespace IdentityApp;
public class Startup {
    public Startup(IConfiguration config) => Configuration = config;
    private IConfiguration Configuration { get; set; }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();
        services.AddDbContext<PersonDbContext>(opts =>
        {
            opts.UseSqlServer(
            Configuration["ConnectionStrings:AppDataConnection"]);
        });
        services.AddHttpsRedirection(opts => {
            opts.HttpsPort = 44350;
        });

        services.AddDbContext<IdentityDbContext>(opts => {
            opts.UseSqlServer(
                Configuration["ConnectionStrings:IdentityConnection"],
                opts => opts.MigrationsAssembly("PersonApp")
            );
        });
        
        services.AddScoped<IPersonRepository, EFPersonRepository>();
        services.AddScoped<IRecordRepository, EFRecordRepository>();
        services.AddScoped<IArrows, Arrows>();
        services.AddScoped<IFileUploadService, LocalFileUploadService>();

        services.AddScoped<IEmailSender, ConsoleEmailSender>();

        services.AddIdentity<IdentityUser, IdentityRole>(opts => {
            opts.Password.RequiredLength = 8;
            opts.Password.RequireDigit = false;
            opts.Password.RequireLowercase = false;
            opts.Password.RequireUppercase = false;
            opts.Password.RequireNonAlphanumeric = false;
            opts.SignIn.RequireConfirmedAccount = true;
        })
        .AddEntityFrameworkStores<IdentityDbContext>()
        .AddDefaultTokenProviders();

        services.Configure<SecurityStampValidatorOptions>(opt => {
            opt.ValidationInterval = System.TimeSpan.FromMinutes(1);
        });

        services.AddScoped<TokenUrlEncoderService>();
        services.AddScoped<IdentityEmailService>();
        

        services.AddAuthentication().AddGoogle(opt => {
            opt.ClientId = Configuration["Google:ClientId"];
            opt.ClientSecret = Configuration["Google:ClientSecret"];
        });
        
        services.ConfigureApplicationCookie(opts => {
            opts.LoginPath = "/Identity/SignIn";
            opts.LogoutPath = "/Identity/SignOut";
            opts.AccessDeniedPath = "/Identity/Forbidden";;
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => {
            endpoints.MapDefaultControllerRoute();
            endpoints.MapRazorPages();
        });

        app.SeedUserStoreForDashboard(); 
    }
}