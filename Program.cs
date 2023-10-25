using MidnightCityTheater.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<APIDbContext>();
builder.Services.AddCors();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MidnightCityTheater", Version = "v1" });
});
var app = builder.Build();

if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MidnightCityTheater V1");
    });
}
app.UseHttpsRedirection(); 
app.UseAuthorization();
app.UseCors(opcoes => opcoes.AllowAnyOrigin().AllowAnyHeader()); 
app.MapControllers(); 
app.Run();