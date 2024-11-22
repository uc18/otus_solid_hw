using NumberCheck.Interfaces;
using NumberCheck.Services;

namespace NumberCheck;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.Configure<ApplicationRandomNumber>(builder.Configuration.GetSection(nameof(ApplicationRandomNumber)));
        builder.Services.AddSingleton<IRandomGeneratorService, RandomGeneratorService>();
        builder.Services.AddSingleton<IUserService, UserService>();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        app.Run();
    }
}