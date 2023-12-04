
using InimcoDemoBackEnd.DatabaseContext;
using InimcoDemoBackEnd.Services;
using Microsoft.EntityFrameworkCore;

namespace InimcoDemoBackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.Development.json")
                .AddEnvironmentVariables()
                .Build();

            // dependency injection
            builder.Services.AddScoped<IPersonService, PersonService>();

            // Add services to the container.
            builder.Services.AddLogging();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //database
            builder.Services.AddDbContext<PersonDatabaseContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DatabaseConnectionString"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
