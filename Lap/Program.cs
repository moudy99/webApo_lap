
using Lap.Models;
using Lap.Repository;
using Microsoft.EntityFrameworkCore;

namespace Lap
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IproductRepository, ProductRepository>();
            builder.Services.AddScoped<IcategoryRepository, CategoryRepository>();

            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=WebApi__;Integrated Security=True;Encrypt=false;");
            });

            builder.Services.AddCors(options =>
            {
                // Here i can declare more than one policy 
                options.AddPolicy("myPolicy_1", policy => policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

                /// Here i allow only the requests form the domain of FACEBOOK .????
                //options.AddPolicy("myPolicy_1", policy => policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("WWW.facebook.com"));


            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // To allow external access 
            app.UseCors("myPolicy_1");


            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
