using BugTracking.Api.Configuration;
using BugTracking.Api.Data;
using BugTracking.Api.Services.AuthService;
using BugTracking.Api.Services.UserService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<Program>()
);

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAuthService, AuthService>();


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();

    await DbConfiguration.SeedDatabaseAsync(serviceProvider);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
