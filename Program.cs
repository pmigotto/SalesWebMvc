using Pomelo.EntityFrameworkCore.MySql;
using SalesWebMvc.Data;

using MySqlConnector;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;


namespace SalesWebMvc {
    public class Program {

        
        public static void Main(string[] args) {


            /*
            using var connection = new MySqlConnection("SalesWebMvcContext");

            connection.OpenAsync();

            using var command = new MySqlCommand("SELECT field FROM table;", connection);
            using var reader = command.ExecuteReader();
            while ( reader.Status.Equals(reader) ) {
                var value = reader.Result;
                // do something with 'value'
                Console.WriteLine(value.ToString());
            }
            */



            //var builder = WebApplication.CreateBuilder();

            ServiceCollection services = new ServiceCollection();


            MySqlConnection connectionString = new MySqlConnection("SalesWebMvcContext");

            

            services.AddDbContext<SalesWebMvcContext>(options => 
                options.UseMySql(connectionString, builder =>
                    builder.MigrationsAssembly("SalesWebMvc"))); 

            // Add services to the container.
            services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
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
