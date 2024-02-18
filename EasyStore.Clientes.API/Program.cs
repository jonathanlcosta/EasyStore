using EasyStore.Clientes.API.Clientes.Commands;
using EasyStore.Clientes.API.Clientes.Data.Mapeamentos;
using EasyStore.Clientes.API.Clientes.Data.Repositorios;
using EasyStore.Clientes.API.Clientes.Profiles;
using EasyStore.Clientes.API.Clientes.Services;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MediatR;
using NHibernate;
using Shared.Utils.Transacoes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(ClienteComando));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISessionFactory>(factory => 
{
    string connectionString = builder.Configuration.GetConnectionString("MySql");
    return Fluently.Configure()
    .Database((MySQLConfiguration.Standard.ConnectionString(connectionString)
    .FormatSql()
    .ShowSql()))
    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<ClientesMap>()) 
    .BuildSessionFactory();
});
builder.Services.AddScoped<NHibernate.ISession>(factory => factory.GetService<ISessionFactory>()!.OpenSession());
builder.Services.AddScoped<ITransaction>(factory => factory.GetService<NHibernate.ISession>()!.BeginTransaction());

builder.Services.AddAutoMapper(typeof(ClientesProfle));
builder.Services.Scan(scan => scan
    .FromAssemblyOf<ClientesServico>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());
builder.Services.Scan(scan => scan
    .FromAssemblyOf<ClientesRepositorio>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<UnitOfWork>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

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
