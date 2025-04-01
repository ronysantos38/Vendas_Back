using System;
using System.Linq;
using System.Text;
using Dominio.Modelo;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Dominio.Interface.Repositorio
{
    public interface IVendaRepository
    {
        void Cadastrar(Venda venda);
        List<Venda> Listar();
        Venda PesquisaPorId(int Vendaid);
        void Atualizar(Venda venda);
        void Excluir(int Vendaid);
        void CarregarDados();
    }
}

 