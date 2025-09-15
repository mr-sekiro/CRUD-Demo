using BusinessLogic.Services.AttachmentService;
using BusinessLogic.Services.Classes;
using BusinessLogic.Services.Interfaces;
using DataAccess.Data.DbContexts;
using DataAccess.Repositories.Classes;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region Add services to the container
            builder.Services.AddControllersWithViews();

            //builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddDbContext<AppDbContext>(dbContextOptions =>
            {
                //dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
                //dbContextOptions.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                dbContextOptions.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                dbContextOptions.UseLazyLoadingProxies();
            }, ServiceLifetime.Scoped);

            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IAttachmentService, AttachmentService>(); 
            #endregion

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
    //Add-Migration "InitialCreate" -OutputDir "Data/Migrations" -Project "DataAccess" -StartupProject "CRUD-Demo" -Verbose
    //Update-Database -Project "DataAccess" -StartupProject "CMS" -Verbose
}
