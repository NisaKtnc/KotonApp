using Koton.Web.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Koton.DAL.Abstract;
using Koton.DAL.Concrete;
using Koton.Business.Abstract;
using Koton.Business.Concrete;
using Koton.Entities.Context;
using AutoMapper;
using System.Reflection;
using Koton.Business.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddAutoMapper(typeof(GeneralMapping));


builder.Services.AddTransient<IProductsService, ProductsService>();

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddDbContext<KotonDbContext>(
    options=>options.UseSqlServer(builder.Configuration.GetConnectionString
    ("DefaultConnection"))
    );

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
