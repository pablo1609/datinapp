using DatingApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyHeader().AllowAnyMethod()
        .WithOrigins("https://localhost:4200"));

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();