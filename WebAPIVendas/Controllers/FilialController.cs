using Dominio.Interface.Services;
using Dominio.Modelo;
using Infra.Contexto;
using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;

namespace WebAPIVendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilialController : ControllerBase
    {
        private readonly IFilialService _filialService;
        private readonly Contexto _contexto;

        public FilialController(IFilialService filialService, Contexto contexto)
        {
            _filialService = filialService;
            _contexto = contexto;
        }

        // GET: /Consulta/
        [HttpGet("CarregarDados")]
        [ActionName("CarregarDados")]
        public void CarregarDados()
        {

            try
            {
                _filialService.CarregarDados();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost("Listar")]
        public ActionResult<List<Filial>> Listar()
        {
            try
            {
                var cli = _filialService.Listar();
                return (cli);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        public ActionResult<IEnumerable<Filial>> PegarTodosAsync()
        {
           return  _filialService.Listar();            
        }

        [HttpPost("Cadastrar")]
        public ActionResult Cadastrar(Filial filial)
        {
            _filialService.Cadastrar(filial);
            // return RedirectToAction("Listar");
            return Ok(); 
        }

        [HttpDelete("{Filialid}")]
        public ActionResult ExcluirFilial(int Filialid)
        {
            _filialService.Excluir(Filialid);
            //return RedirectToAction("Listar");
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarFilialAsync(Filial filial)
        {
            _filialService.Atualizar(filial);
            return Ok();
        }

        [HttpGet("{Filialid}")]
        public async Task<ActionResult<Filial>> PegarFilialPeloIdAsync(int Filialid)
        {

            Filial filial = _filialService.PesquisaPorId(Filialid);            

            if (filial == null)
                return NotFound();

            return filial;
        }
     
    }
}
