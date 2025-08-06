using System.Text;
using EstadioIQ.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using EstadioIQ.Helper.AuthHelper;
using EstadioIQ.DAL.Interface;
using EstadioIQ.DAL.Repository;
using EstadioIQ.BAL.Services;
using EstadioIQ.BAL.Interface;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Configuration;
using EstadioIQ.Helper.ApiServices;
using EstadioIQ.Helper.Converter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<AuthHelper>();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("APISettings"));
builder.Services.AddTransient<MatchConverter>();
builder.Services.AddTransient<FootballAPIService>();

builder.Services.AddHttpClient(); // Registers IHttpClientFactory

//Repositories
builder.Services.AddScoped<IApplicationUserRepo, ApplicationUserRepo>();
builder.Services.AddScoped<IPlayerRepo, PlayerRepo>();
builder.Services.AddScoped<IMatchRepo, MatchRepo>();
builder.Services.AddScoped<IMatchPerformanceRepo, MatchPerformanceRepo>();

//Services
builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IMatchPerformanceService, MatchPerformanceService>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString)
);

builder.Services.AddAuthentication(cfg => {
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8
            .GetBytes(builder.Configuration["ApplicationSettings:JWT_Secret"])
        ),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT token (e.g. Bearer eyJhbGci...)",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        { securityScheme, Array.Empty<string>() }
    };

    c.AddSecurityRequirement(securityRequirement);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
    RequestPath = "/playerImage"
});

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
