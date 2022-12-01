using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using WeatherApp.Application;
using WeatherApp.Persistance;
using WeatherApp.Persistance.Context;
using WeatherApp.Persistance.Helper;
using Microsoft.OpenApi.Models;
using System.Text;
using WeatherApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//add infrastructure - persistance layer dependencies
builder.Services.AddPersistanceServices();

//add core - application layer dependencies
builder.Services.AddApplicationRegistraion();

//add  infrastructure - infrastructure layer dependencies
builder.Services.AddInfrastructureServices();
//add authentication jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["TokenOptions:Issuer"],
        ValidAudience = builder.Configuration["TokenOptions:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenOptions:SecurityKey"])),

    };
});

//add http client and base address
builder.Services.AddHttpClient("openweathermap", config =>
{
    config.BaseAddress = new Uri("http://api.openweathermap.org");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt => opt.AddDefaultPolicy(p => { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345.54321\""
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
                { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    //3. Get the instance of ApplicationDbContext in our services layer
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    //4. Call the SeedDataGenerator to create sample data
    SeedDataGenerator.Initialize(services);
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(opt =>
                opt.WithOrigins("http://localhost:7202", "http://localhost:5122", "http://localhost:3000", "http://localhost:3001")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials());
app.Run();

