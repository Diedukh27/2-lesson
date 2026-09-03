using _1_lesson.Data;
using _1_lesson.Data.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppQrDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("QrConnection")));

builder.Services.AddIdentity<UserEntity, RoleEntity>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
})
    .AddEntityFrameworkStores<AppQrDbContext>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();

app.MapControllers();

await app.SeedData();

app.Run();
