using Dominio.Modelo;
using Infra.Contexto;
using Servico.Servicos;
using Microsoft.AspNetCore.Mvc;
using Dominio.Interface.Services;


namespace WebAPIVendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendaController : ControllerBase
    {        
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VendaGerada>> PegarTodosAsync()
        {
            return _vendaService.ListarVendaRealizada();
        }

        [HttpPost("GerarVenda")]
        public ActionResult GerarVenda(List<VendaEfetuada> vendaEfetuada)
        {
            _vendaService.CadastrarVendaRealizada(vendaEfetuada);
            // _produtoService.Cadastrar(produto);
            return Ok();
        }
        
        [HttpGet("TipoVenda/{TipoVenda}")]
        public ActionResult<IEnumerable<VendaGerada>> TipoVenda(string TipoVenda)        
        {
            return _vendaService.ListarTipVenda(TipoVenda);
        }

        [HttpGet("ListarVenda")]
        public ActionResult<IEnumerable<VendaListada>> ListarVenda()
        {
            return _vendaService.ListarVenda();
        }

        [HttpPut("CancelarVenda/{Vendaid}")]
        public ActionResult CancelarVenda(int Vendaid)
        {
           _vendaService.CancelarVenda(Vendaid);
            return Ok();
        }      
        
      
        [HttpGet("RetornaVendaRealizada/{Vendaid}")]
        public async Task<List<VendaGerada>> RetornaVendaRealizada(int Vendaid)
        {
            return _vendaService.PesquisaVendaVendaId(Vendaid);                         
        }

        [HttpGet("RetornaVendaRealizadaItem/{Vendaid}/{produtoid}")]
        public async Task<VendaListadaGeral> RetornaVendaRealizadaItem(int Vendaid, int produtoid)
        {
            return _vendaService.PesquisaVendaVendaItem(Vendaid, produtoid);

        }

        [HttpPut("ModificarVenda")]
        public ActionResult ModificarVenda(VendaEfetuada vendaEfetuada)
        {
            _vendaService.ModificarVenda(vendaEfetuada);
            // _produtoService.Cadastrar(produto);
            return Ok();
        }

        [HttpPost("ModificarVendaRealizada")]
        public ActionResult ModificarVendaRealizada(List<VendaEfetuada> vendaEfetuada)
        {
            _vendaService.ModificarVendaRealizada(vendaEfetuada);
            // _produtoService.Cadastrar(produto);
            return Ok();
        }

    }
}
