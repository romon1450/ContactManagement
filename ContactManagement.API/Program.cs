using ContactManagement.API.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

var allowAllOrigins = "AllowAll";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ContactManagementDbContext>(options => options.UseSqlServer(dbConnectionString));
builder.Services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

var app = builder.Build();

app.UseCors(allowAllOrigins);

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
