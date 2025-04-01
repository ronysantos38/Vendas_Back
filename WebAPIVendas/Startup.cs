using Dominio.Interface.Repositorio;
using Dominio.Interface.Services;
using Infra.Contexto;
using Infra.Repositorio;
using Microsoft.EntityFrameworkCore;
using Servico.Servicos;

namespace WebAPIVendas
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<Contexto>(opcoes => opcoes.UseSqlServer(Configuration.GetConnectionString("ConexaoBD")));

            services.AddDbContext<Contexto>(opcoes => opcoes.UseSqlServer("Data Source=DESKTOP-DUEH459\\SQLEXPRESS;Initial Catalog=Exemplos8;Integrated Security=False;User Id=sa;Password=copola;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"));
            services.AddCors();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();


            services.AddScoped<IFilialService, FilialService>();
            services.AddScoped<IFilialRepository, FilialRepository>();

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaRepository, VendaRepository>();

            services.AddScoped<IVendaRealizadaService, VendaRealizadaService>();
            services.AddScoped<IVendaRealizadaRepository, VendaRealizadaRepository>();
            

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(opcoes => opcoes.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            app.UseAuthorization();
            app.MapControllers();
        }


    }
}
