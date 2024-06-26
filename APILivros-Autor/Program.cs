using APILivros_Autor.Data;
using APILivros_Autor.Services.AutorService;
using APILivros_Autor.Services.LivroService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAutorInterface, AutorService>();
builder.Services.AddScoped<ILivroInterface, LivroService>();

var DefaultConnection = "server=localhost;userid=root;password=895smigol;database=LivroAutor;";

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(DefaultConnection, ServerVersion.AutoDetect(DefaultConnection));
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
