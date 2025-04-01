using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.Interface.Services
{
    public interface IProdutoService
    {
        void Cadastrar(Produto produto);
        List<Produto> Listar();
        Produto PesquisaPorId(int Produtoid);
        void Atualizar(Produto produto);
        void Excluir(int Produtoid);
        void CarregarDados();
        List<ProdutoFilial> ListarProdutoFilial();
        ProdutoFilial PesquisaProdutoFilialId(int Produtoid);
        Produto PesquisaPorFilialId(int Filialid);
        List<Produto> ListarProdutoFilialId(int Filialid);
    }
}
