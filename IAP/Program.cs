using IAP.Infrustructure;
using IAP.Web;
using IAP.Web.Middleweres;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static IAP.Web.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebApiServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddServices();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.Map("/login/{username}", (string username) =>
{
    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
    var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(30)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

    return new JwtSecurityTokenHandler().WriteToken(jwt);
});
app.UseAuthorization();
app.UseMiddleware<JWTMiddleware>();
app.UseSwagger();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
