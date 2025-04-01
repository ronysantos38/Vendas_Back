using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface.Services
{
    public interface IVendaService
    {
        void Cadastrar(Venda venda);
        List<Venda> Listar();
        Venda PesquisaPorId(int Vendaid);
        void Atualizar(Venda venda);
        void Excluir(int Vendaid);
        void CarregarDados();
        List<VendaGerada> ListarVendaRealizada();
        List<VendaGerada> PesquisaVendaVendaId(int Vendaid);
        void CadastrarVendaRealizada(List<VendaEfetuada> vendaEfetuada);
        void SalvarVendaRealizada(VendaRealizada vendaRealizada);
        List<VendaGerada> ListarTipVenda(string TipoVenda);
        List<VendaListada> ListarVenda();
        void CancelarVenda(int Vendaid);        
        void AtualizarVendaRealizada(VendaRealizada vendaRealizada);

        VendaListadaGeral PesquisaVendaVendaItem(int Vendaid, int produtoid);

        void ModificarVenda(VendaEfetuada vendaEfetuada);

        void ModificarVendaRealizada(List<VendaEfetuada> vendaEfetuada);

    }
}


