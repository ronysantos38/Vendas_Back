using Dominio.Interface.Repositorio;
using Dominio.Interface.Services;
using Dominio.Modelo;
using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;

namespace WebAPIVendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
              

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: /Consulta/
        [HttpGet("CarregarDados")]
        [ActionName("CarregarDados")]
        public void CarregarDados()
        {           

            try
            {
                _clienteService.CarregarDados();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        
      
        [HttpPost("Listar")]
        public ActionResult<List<Cliente>> Listar()
        {
            try
            {
                var cli = _clienteService.Listar();
                return (cli);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> PegarTodosAsync()
        {
            return _clienteService.Listar();
        }

        [HttpPost("Cadastrar")]
        public ActionResult Cadastrar(Cliente cliente)
        {
            _clienteService.Cadastrar(cliente);
            return Ok();
        }

        [HttpDelete("{Clienteid}")]
        public ActionResult ExcluirCliente(int Clienteid)
        {
            _clienteService.Excluir(Clienteid);
            return Ok();
        }
      
        [HttpPut]
        public async Task<ActionResult> AtualizarClienteAsync(Cliente cliente)
        {
            _clienteService.Atualizar(cliente);
            return Ok();
        }

        [HttpGet("{Filialid}")]
        public async Task<ActionResult<Cliente>> PegarFilialPeloIdAsync(int Filialid)
        {

            Cliente cliente = _clienteService.PesquisaPorId(Filialid);

            if (cliente == null)
                return NotFound();

            return cliente;
        }



    }
}
