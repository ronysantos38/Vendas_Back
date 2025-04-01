using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface.Repositorio
{
    public interface IVendaRealizadaRepository
    {
        void Cadastrar(VendaRealizada venda);
        List<VendaRealizada> Listar();
        VendaRealizada PesquisaPorId(int Vendaid);
        void Atualizar(VendaRealizada venda);
        void Excluir(int Vendaid);
        void CarregarDados();
    }
}




