using Microsoft.EntityFrameworkCore;
using NvyLesson10EFDbFist.Model;

namespace NvyLesson10EFDbFist
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // lấy chuỗi kết nối từ appsettings.json
            var nvyConnection = builder.Configuration.GetConnectionString("NvyK24cntt2Lesson10EFdbContext");
            builder.Services.AddDbContext<NvyK24cntt2Lesson10EfdbContext>(options => options.UseSqlServer(nvyConnection));

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
}
