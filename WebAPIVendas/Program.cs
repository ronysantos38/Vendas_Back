using Dominio.Interface.Repositorio;
using Dominio.Interface.Services;
using Infra.Repositorio;
using Servico.Servicos;
using WebAPIVendas;
//using WebAPIVendas;


var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);
app.Run();


//namespace WebAPIVendas
//{
//public class Program
//{
//public static void Main(string[] args)
//{
//    var builder = WebApplication.CreateBuilder(args);

//    // Add services to the container.

//    builder.Services.AddControllers();
//    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//    builder.Services.AddEndpointsApiExplorer();

//    builder.Services.AddScoped<IClienteService, ClienteService>();
//    builder.Services.AddScoped<IClienteRepository, ClienteRepository>();



//    builder.Services.AddSwaggerGen();

//    var app = builder.Build();

//    // Configure the HTTP request pipeline.
//    if (app.Environment.IsDevelopment())
//    {
//        app.UseSwagger();
//        app.UseSwaggerUI();
//    }

//    app.UseHttpsRedirection();

//    app.UseAuthorization();


//    app.MapControllers();

//    app.Run();
//}



//    }


//}
