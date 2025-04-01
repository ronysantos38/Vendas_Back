using Dominio.Interface.Services;
using Dominio.Modelo;
using Infra.Contexto;
using Microsoft.AspNetCore.Mvc;
using Servico.Servicos;

namespace WebAPIVendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
        _produtoService = produtoService;
        }
                
        [HttpGet("ListarProdutos")] 
        public ActionResult<IEnumerable<ProdutoFilial>> PegarTodosAsync()
        {
            return _produtoService.ListarProdutoFilial();
        }

        [HttpPost("Cadastrar")]
        public ActionResult Cadastrar(Produto produto)
        {
            _produtoService.Cadastrar(produto);
            return Ok();
        }

        [HttpDelete("{Produtoid}")]
        public ActionResult ExcluirProduto(int Produtoid)
        {
            _produtoService.Excluir(Produtoid);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> AtualizarProdutoAsync(Produto produto)
        {
            _produtoService.Atualizar(produto);
            return Ok();
        }

        [HttpGet("{Produtoid}")]
        public async Task<ActionResult<ProdutoFilial>> PegarProdutoPeloIdAsync(int Produtoid)
        {

            ProdutoFilial Produto = _produtoService.PesquisaProdutoFilialId(Produtoid);

            if (Produto == null)
                return NotFound();

            return Produto;
        }
       
        [HttpGet("CarregarFilial/{Filialid}")]
        public ActionResult<IEnumerable<Produto>> PegarProdutoFilialIdAsync(int Filialid)
        {

            var produto = _produtoService.ListarProdutoFilialId(Filialid);

            if (produto == null)
                return NotFound();

            return produto;
        }

    }
}
