using FluentAssertions.Common;
using HMS_WebApi_v1._0;
using HMS_WebApi_v1._0.Bootstraps;
using Microsoft.EntityFrameworkCore;
using Repository.DataAccess;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddLogicServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBContext>(options =>
{
    options.UseSqlServer("Data Source=DESKTOP-J7CUSB6\\SQLEXPRESS;Initial Catalog = HMSLocalDB; User id=sa; Password=test; TrustServerCertificate=True");
});
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