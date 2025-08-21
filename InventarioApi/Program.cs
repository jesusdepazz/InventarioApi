using Inventory.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InventarioContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        builder.Configuration.Bind("AzureAd", options);

        options.Authority = $"{builder.Configuration["AzureAd:Instance"]}{builder.Configuration["AzureAd:TenantId"]}";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidAudience = builder.Configuration["AzureAd:Audience"],
            ValidateIssuer = true
        };
    });

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.MaxDepth = 64;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("react", policy =>
    {
        policy.WithOrigins("https://inventory-test.guandy.com")
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

app.UseCors("react");

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
