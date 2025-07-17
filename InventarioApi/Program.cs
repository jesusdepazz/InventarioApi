using Inventory.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InventarioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("https://inventory.guandy.com")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });

});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Inventario API V1");
    c.RoutePrefix = "swagger";
});


app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.UseStaticFiles(); 

app.MapControllers();

app.Run();
