
using InimcoDemoBackEnd.DatabaseContext;
using InimcoDemoBackEnd.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

            #region dependency injection
            builder.Services.AddScoped<IPersonService, PersonService>();
            #endregion

            #region Add services to the container.
            builder.Services.AddLogging(logging =>
            {
                logging.AddConsole(); // Add console logging
            });
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    //TODO: Tighten security
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            //database
            builder.Services.AddDbContext<PersonDatabaseContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DatabaseConnectionString"));
            });
            #endregion

            #region App Building
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            #endregion
        }
    }
}
