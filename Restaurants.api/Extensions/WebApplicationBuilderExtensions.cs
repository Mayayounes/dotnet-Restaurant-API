//using Microsoft.OpenApi.Models;
using Restaurants.API.Middlewares;
using Serilog;

namespace Restaurants.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
    //    builder.Services.AddSwaggerGen(static c =>
    //    {
    //        c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    //        {
    //            Type = SecuritySchemeType.Http,
    //            Scheme = "bearer",
    //            BearerFormat = "JWT",
    //            In = ParameterLocation.Header,
    //            Name = "Authorization",
    //            Description = "Enter JWT Bearer token"
    //        });

    //        c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "bearerAuth"  // must match the security definition name
    //            },
    //            Scheme = "bearer",
    //            Name = "Authorization",
    //            In = ParameterLocation.Header,
    //        },
    //        new List<string>()
    //    }
    //});
    //    });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
        );
    }
}
