using api.Data;
using api.Repositories;
using api.Repositories.Interfaces;
using api.Services;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddScoped<IPratoRepository, PratoRepository>();

builder.Services.AddScoped<IPratoService, PratoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(c =>
{
    c.InjectStylesheet("https://cdn.jsdelivr.net/npm/swagger-ui-themes@3.0.0/themes/3.x/theme-monokai.css");
});


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
