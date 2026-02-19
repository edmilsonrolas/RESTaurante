using api.Data;
using api.Repositories;
using api.Repositories.Interfaces;
using api.Services;
using api.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// -------------------- Controllers --------------------
builder.Services.AddControllers();

// -------------------- FluentValidation --------------------
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// -------------------- Swagger --------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -------------------- Database --------------------
builder.Services.AddDbContext<ApplicationDBContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));

//----------------------------------------------------
builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDBContext>();

// -------------------- Repositories --------------------
builder.Services.AddScoped<IPratoRepository, PratoRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();

// -------------------- Services --------------------
builder.Services.AddScoped<IPratoService, PratoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
