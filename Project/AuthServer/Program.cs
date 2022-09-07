using AuthServer.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//builder.Services.AddSingleton<ITokenService>(new TokenService());
builder.Services.AddDbContext<ProjectDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));
builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
await using var app = builder.Build();
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

await app.RunAsync();


//internal record UserValidationRequestModel([Required]string UserName, [Required] string Password);

//internal interface ITokenService
//{
//    string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName);
//}
//internal class TokenService : ITokenService
//{
//    private TimeSpan ExpiryDuration = new TimeSpan(20, 30, 0);
//    public string BuildToken(string key, string issuer, IEnumerable<string> audience, string userName)
//    {
//        var claims = new List<Claim>
//        {
//            new Claim(JwtRegisteredClaimNames.UniqueName, userName),
//        };

//        claims.AddRange(audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));

//        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
//        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
//        var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
//            expires: DateTime.Now.Add(ExpiryDuration), signingCredentials: credentials);
//        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
//    }
//}
