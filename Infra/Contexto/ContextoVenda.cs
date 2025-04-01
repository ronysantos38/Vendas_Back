
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelo;

namespace Infra.Contexto
{
    public class ContextoVenda
    {
        public static List<Cliente> Clientes;
        public static List<Produto> Produtos;
        public static List<Filial> Filiais;

        static ContextoVenda()
        {
            Clientes = new List<Cliente>();
            Produtos = new List<Produto>();
            Filiais = new List<Filial>();
        }

        //private static void inicializaDados()
        public void inicializaDados()
        {
            //var cliente = new Cliente(1, "james");
            //Clientes.Add(cliente);


            //cliente = new Cliente(2, "Flavia");
            //Clientes.Add(cliente);


            //cliente = new Cliente(3, "Santos");
            //Clientes.Add(cliente);

        }
    }
}