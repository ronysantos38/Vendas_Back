using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface.Services
{
    public interface IVendaRealizadaService
    {
        void Cadastrar(VendaRealizada venda);
        List<VendaRealizada> Listar();
        Venda PesquisaPorId(int VendaRealizadaid);
        void Atualizar(VendaRealizada venda);
        void Excluir(int VendaRealizadaid);
        void CarregarDados();
        List<VendaRealizada> ListarVendaRealizada();
        VendaRealizada PesquisaRealizadaId(int VendaRealizadaid);
    }
}


 