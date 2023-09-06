using CompanyServices.Api.Data;
using CompanyServices.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using TransactionBankServices.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<TransactionDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));
//var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//var dbName = Environment.GetEnvironmentVariable("DB_NAME");
//var dbPaswword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
//var connectionstring = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPaswword}";
//builder.Services.AddDbContext<TransactionDbContext>(options =>options.UseSqlServer(connectionstring));
//add scoped
builder.Services.AddScoped<ICompany, CompanyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
