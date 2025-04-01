using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface.Repositorio
{
    public interface IClienteRepository
    {
        void Cadastrar(Cliente cliente);
        List<Cliente> Listar();
        Cliente PesquisaPorId(int Id);
        void Atualizar(Cliente cliente);
        void Excluir(int Id);
        void CarregarDados();
    }
}
