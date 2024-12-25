using BloodBankProject.DAL.Data.Models;
using BloodBankProject.DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BloodBankProject.DAL.Repositories.DonerRepository;
using BloodBankProject.BLL.Managers.DonorManager;
using BloodBankProject.BLL.Managers.DonationManager;
using BloodBankProject.DAL.Repositories.DonationRepository;
using BloodBankProject.DAL.Repositories.BloodStockRepository;
using BloodBankProject.BLL.Managers.BloodStockManager;
using BloodBankProject.DAL.Repositories.EmailReposirory;
using BloodBankProject.DAL.Repositories.RequestRepository;
using BloodBankProject.BLL.Managers.RequestManager;
using BloodBankProject.DAL.Repositories.PendingRequestRepository;
using BloodBankProject.DAL.Repositories.HospitalRepository;
using BloodBankProject.BLL.Managers.HospitalManager;

namespace BloodBankProject.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<BloodBankDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CS")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<BloodBankDBContext>();

            builder.Services.AddScoped<IDonorRepo, DonorRepo>();
            builder.Services.AddScoped<IDonorManager, DonorManager>();

            builder.Services.AddScoped<IDonationRepo, DonationRepo>();
            builder.Services.AddScoped<IDonationManager, DonationManager>();

            builder.Services.AddScoped<IBloodStockRepo, BloodStockRepo>();
            builder.Services.AddScoped<IBloodStockManager, BloodStockManager>();

            builder.Services.AddScoped<IRequestRepo, RequestRepo>();
            builder.Services.AddScoped<IRequestManager, RequestManager>();

            builder.Services.AddScoped<IHospitalRepo, HospitalRepo>();
            builder.Services.AddScoped<IHospitalManager, HospitalManager>();

            builder.Services.AddScoped<IPendingRequestRepo, PendingRequestRepo>();

            builder.Services.AddScoped<IEmailRepo, EmailRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
