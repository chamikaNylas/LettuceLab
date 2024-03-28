using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence;
using Persistence.Repositories.Interfaces;
using Persistence.Repositories;
using Domain.Entities;
using MediatR;
using Application.Queries.GreenHouseQuery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configure db
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

//registor mediatorR
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetGreenHousesQueryHandler).Assembly));
//registorquery repo 
builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
// Register UnitOfWorkCommands
builder.Services.AddScoped<IUnitOfWorkCommand, UnitOfWorkCommands>();
//registor application
builder.Services.AddApplication(Configuration);
//registor mediatorR handlers
//builder.Services.AddScoped<IRequestHandler<GetGreenHousesQuery, IEnumerable<GreenHouseDto>>, GetGreenHousesQueryHandler>();


builder.Services.AddScoped<GetRepo>();

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
