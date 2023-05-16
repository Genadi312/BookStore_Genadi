using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.DL.Repositories.MongoDb;
using BookStore.Models.Configurations;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using FluentValidation.AspNetCore;
using FluentValidation;
using BookStore.Extensions;
using BookStore.HealthChecks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console(theme: AnsiConsoleTheme.Code).CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.AddSerilog(logger);

            builder.Services.Configure<MongoDbConfiguration>(builder.Configuration.GetSection(nameof(MongoDbConfiguration)));

            // Add services to the container.
            builder.Services.AddSingleton<IAuthorServices, AuthorService>();
            builder.Services.AddSingleton<IAuthorRepository, AuthorMongoRepository>();
            builder.Services.AddSingleton<IBookServices, BookService>();
            builder.Services.AddSingleton<ILibraryServices, LibraryServices>();
            builder.Services.AddSingleton<IBookRepository,BookMongoRepository>();
            builder.Services.AddSingleton<IUserInfoService, UserInfoService>();
            builder.Services.AddSingleton<IUserInfoRepository, UserInfoMongoRepository>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jwt: Key"))
                };
            });

            builder.Services.AddAutoMapper(typeof(Program));

            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme()
                {
                   Scheme = "bearer",
                   BearerFormat = "JWT",
                   Name = "JWT Authentication",
                   In = ParameterLocation.Header,
                   Type = SecuritySchemeType.Http,
                   Description ="Put **_Only_** JWT Bearer token",
                   Reference = new OpenApiReference()
                   {
                       Id = JwtBearerDefaults.AuthenticationScheme,
                       Type = ReferenceType.SecurityScheme
                   }
                };

                x.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {jwtSecurityScheme, Array.Empty<string>()}
                });
            });

            builder.Services.AddHealthChecks().AddCheck<MongoHealthCheck>("MongoDB").AddUrlGroup(new Uri("https://google.bg"), "My Service");
            builder.Services.AddHealthChecks().AddCheck<BookCheck>("BookCheck");
            

            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();

            app.RegisterHealthChecks();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}