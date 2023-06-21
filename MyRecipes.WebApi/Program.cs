using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyRecipes.Database;
using MyRecipes.Database.Managers;
using MyRecipes.Domain.Business;
using MyRecipes.Domain.Interfaces.Business;
using MyRecipes.Domain.Interfaces.Managers;
using MyRecipes.WebApi.Identity;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TineosProject.API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        Description = "\"Bearer Token\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
        }
    });
});

//DataBase Di
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UsersCnxStr")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //ValidIssuer = builder.Configuration.GetConnectionString("Issuer"),
        //ValidAudience = builder.Configuration.GetConnectionString("Audience"),
        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetConnectionString("Secret"))),

        ValidIssuer = "MyRecipesAPI",
        ValidAudience = "Audience",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ForTheLoveOfGodStoreAndLoadThisSecurely")),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization( options =>
{
    options.AddPolicy(IdentityData.AdminUserPolicyName, p => p.RequireClaim(IdentityData.AdminUserClaimName, "true"));
    options.AddPolicy(IdentityData.SimpleUserPolicyName, p => p.RequireClaim(IdentityData.SimpleUserClaimName, "true"));
});

//Di
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IRecipesUserManager, RecipesUserManager>();
builder.Services.AddScoped<IRecipesUserBusiness, RecipesUserBusiness>();
builder.Services.AddScoped<IIngredientManager, IngredientManager>();
builder.Services.AddScoped<IIngredientBusiness, IngredientBusiness>();
builder.Services.AddScoped<IRecipesBusiness, RecipesBusiness>();
builder.Services.AddScoped<IRecipesManager, RecipesManager>();
builder.Services.AddScoped<ICookingStepsBusiness, CookingStepBusiness>();
builder.Services.AddScoped<ICookingStepsManager, CookingStepManager>();

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
