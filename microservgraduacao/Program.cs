using microservgraduacao.Graduacao.Entities;
using microservgraduacao.Graduacao.Services.DesempenhoService;
using microservgraduacao.Graduacao.Services.DisciplinasService;
using microservgraduacao.Graduacao.Services.EnsalamentoService;
using microservgraduacao.Graduacao.Services.TurmasService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryDbContext>();
builder.Services.AddScoped<IDisciplinaService, DisciplinaService>();
builder.Services.AddScoped<ITurmaService, TurmaService>();
builder.Services.AddScoped<IEnsalamentoService, EnsalamentoService>();
builder.Services.AddScoped<IHorarioService, HorarioService>();
builder.Services.AddScoped<IDesempenhoService, DesempenhoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//IMPORTANTE!!!
app.MapControllers();


app.Run();

