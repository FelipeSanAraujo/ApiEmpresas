using EmpresasApi.Infra.Data.Contexts;
using EmpresasApi.Infra.Data.Interfaces;
using EmpresasApi.Infra.Data.Repositories;
using EmpresasApi.Services.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configuração do Repositório

//ler a connectionstring do banco de dados (/appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("BDEmpresasApi");

//configurar as classes e interfaces do EntityFramework (Infra.Data)
//definindo para o EntityFramework a connectionstring do banco de dados
builder.Services.AddDbContext<SqlServerContext>(s => s.UseSqlServer(connectionString));

//mapear as interfaces/classes do repositorio
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IEmpresaRepository, EmpresaRepository>();

#endregion

#region Autenticação JWT

var settings = builder.Configuration.GetSection("TokenSettings");
builder.Services.Configure<TokenSettings>(settings);

var section = settings.Get<TokenSettings>();
var key = Encoding.ASCII.GetBytes(section.SecretKey);

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(bearer => {
    bearer.RequireHttpsMetadata = false;
    bearer.SaveToken = true;
    bearer.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddTransient(map => new TokenCreator(section));

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();



