using Demo.BusniessLogicLayer.Interfaces;
using Demo.BusniessLogicLayer.Rebositories;
using Demo.DataAccessLayer.Data.Contexts;
using Demo.DataAccessLayer.Rebositories;
using Demo.Persentation.MappingProfiles;
using Microsoft.EntityFrameworkCore;
namespace Demo.Persentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllersWithViews();
            // builder.Services.AddScoped<ApplicationDbContext>();// 2 Register to service in DI Container
            builder.Services.AddDbContext<ApplicationDbContext>(options => {
              //  options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]) ;
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));


            });
            //builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRebository>();
            builder.Services.AddAutoMapper(M=>M.AddProfile(new EmployeeProfile()));
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            #endregion
            var app = builder.Build();

           #region Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();
            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
    }
}
