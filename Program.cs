using Microsoft.EntityFrameworkCore;
using JqdIdentityApp.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? 
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services
    .AddJwtAuthentication(builder.Configuration)
    .AddIdentityServices()
    .AddAppServices();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
