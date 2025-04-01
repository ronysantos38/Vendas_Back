using Dominio.Interface.Repositorio;
using Dominio.Modelo;
using Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.Interface.Repositorio;
using Dominio.Interface.Services;
using Dominio.Modelo;
using Infra.Contexto;
using Infra.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class ProdutoRepository :IProdutoRepository
  //  public class ProdutoRepository<T> : IProdutoRepository<T> where T : class
    {
        private readonly ContextoVenda contextoVenda = new ContextoVenda();
        //  private readonly Infra.Contexto _contexto =new Infra.Contexto();
        //private readonly Contexto _contexto = new Contexto();

        //public readonly Contexto _contexto;

        //public ProdutoRepository(Contexto contexto)
        //{
        //    _contexto = contexto;   
        //}

        public void Atualizar(Produto produto)
        {
            var objClientes = PesquisaPorId(produto.Produtoid);
            ContextoVenda.Produtos.Remove(objClientes);

            objClientes.Nome = produto.Nome;

            Cadastrar(objClientes);
        }

        public void Cadastrar(Produto produto)
        {
            ContextoVenda.Produtos.Add(produto);
        }

        public void CarregarDados()
        {
            contextoVenda.inicializaDados();
        }

        public void Excluir(int Produtoid)
        {
            var objCli = PesquisaPorId(Produtoid);
            ContextoVenda.Produtos.Remove(objCli);
        }

        public List<Produto> Listar()
        {         
            var cli = ContextoVenda.Produtos;
            return cli.OrderBy(x => x.Nome).ToList();
        }

        public Produto PesquisaPorId(int Produtoid)
        {
            var cli = ContextoVenda.Produtos.FirstOrDefault(p => p.Produtoid == Produtoid);
            return cli;
        }
    }
}
