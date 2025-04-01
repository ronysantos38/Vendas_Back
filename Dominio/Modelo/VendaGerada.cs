using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
    public class VendaGerada
    {
        public int vendaGeradaid { get; set; }
        public int Vendaid { get; set; }        
        public int Produtoid { get; set; }
        public int Filialid { get; set; }
        public int Clienteid { get; set; }
        public string NomeProduto { get; set; }
        public string NomeFilial { get; set; }
        public string NomeCliente { get; set; }
        public DateTime dataVenda { get; set; }
        public decimal valor { get; set; }
        public decimal desconto { get; set; }
        public int qtde { get; set; }
        public decimal total { get; set; }
    }
}
