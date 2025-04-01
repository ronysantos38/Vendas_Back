using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface.Services
{
    public interface IClienteService
    {
        void Cadastrar(Cliente cliente);
        List<Cliente> Listar();
        Cliente PesquisaPorId(int Clienteid);
        void Atualizar(Cliente cliente);
        void Excluir(int Clienteid);
        void CarregarDados();
    }
}


