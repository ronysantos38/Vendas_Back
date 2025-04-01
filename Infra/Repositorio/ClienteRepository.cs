using Dominio.Interface.Repositorio;
using Dominio.Modelo;
using Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorio
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ContextoVenda contextoVenda =new ContextoVenda();
       // private readonly Contexto contex;
        

        public void Atualizar(Cliente cliente)
        {
            var objClientes = PesquisaPorId(cliente.Clienteid);
            ContextoVenda.Clientes.Remove(objClientes);

            objClientes.Nome = cliente.Nome;            

            Cadastrar(objClientes); 
        }

        public void Cadastrar(Cliente cliente)
        {
            ContextoVenda.Clientes.Add(cliente);
        }

        public void CarregarDados()
        {
            contextoVenda.inicializaDados();
        }

        public void Excluir(int Id)
        {
            var objCli = PesquisaPorId(Id);
            ContextoVenda.Clientes.Remove(objCli);
        }

        public List<Cliente> Listar()
        {
            //   Cliente<List<Cliente>> resposta = new Cliente<List<Cliente>>();

         //   var cli = Contexto.
            var cli = ContextoVenda.Clientes;
            return cli.OrderBy(x => x.Nome).ToList();
        }

        public Cliente PesquisaPorId(int Id)
        {
            var cli = ContextoVenda.Clientes.FirstOrDefault(p => p.Clienteid == Id);
            return cli;
        }
    }
}


