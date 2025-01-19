using eCommerce.Infra.IoC;
using eCommerce.Application;
using eCommerce.API.Filters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(config => // est� fun��o � para habilitar informar o token no swagger
{
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Jwt vai ser enviado no header, digite 'bearer <token>'",
        In = ParameterLocation.Header,
        BearerFormat = "JWT",
        Scheme = "Bearer",
        Type = SecuritySchemeType.ApiKey
    });

    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "OAuth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfra(builder.Configuration);
builder.Services.AddInfraJWT(builder.Configuration);

builder.Services.AddDependencyInjectionApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
