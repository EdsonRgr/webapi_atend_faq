using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebAPI_Atend_FAQ.DataContext;
using WebAPI_Atend_FAQ.Service.DuvidasService;
using WebAPI_Atend_FAQ.Service.SolicitacaoService;
using WebAPI_Atend_FAQ.Service.UsuarioService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISolicitacaoInterface, SolicitacaoService>();
builder.Services.AddScoped<IDuvidasInterface, DuvidasServices>();
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetion"));
});

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
