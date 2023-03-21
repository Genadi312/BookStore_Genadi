using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.DL.Repositories.InMemoriesRepositories;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console(theme: AnsiConsoleTheme.Code).CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.AddSerilog(logger);

            // Add services to the container.
            builder.Services.AddSingleton<IAuthorServices, AuthorService>();
            builder.Services.AddSingleton<IAuthorRepository, AuthorInMemoryRepository>();
            builder.Services.AddSingleton<IBookServices, BookService>();
            builder.Services.AddSingleton<IBookRepository, BookInMemoryRepository>();
            builder.Services.AddSingleton<ILibraryServices, LibraryServices>();

            builder.Services.AddAutoMapper(typeof(Program));

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}