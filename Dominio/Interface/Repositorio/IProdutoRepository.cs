using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio.Interface.Repositorio
{
    public interface IProdutoRepository
    {
        void Cadastrar(Produto produto);
        List<Produto> Listar();
        Produto PesquisaPorId(int Produtoid);
        void Atualizar(Produto produto);
        void Excluir(int Produtoid);
        void CarregarDados();
    }
}
